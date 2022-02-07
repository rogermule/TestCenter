using System;
using System.Collections.Generic;
using System.Text;
using TestCenter.Core.Models;
using TestCenter.Data.Context;

namespace TestCenter.Data.Repository
{
    public class UnitOfWork : IDisposable
    {

        private TestCenterContext _pcrContext;
        private IRepository<Booking> _bookings;
        private IRepository<PcrCenter> _pcrCenters;
        private IRepository<TestCenterAvailability> _testCenterAvailabilities;
        private IRepository<TestReport> _testReports;
        private IRepository<User> _users;


        public UnitOfWork(TestCenterContext pcrContext)
        {
            _pcrContext = pcrContext;
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (_bookings == null)
                    _bookings = new Repository<Booking>(_pcrContext);
                return _bookings;
            }
        }

        public IRepository<PcrCenter> PcrCenters
        {
            get
            {
                if (_pcrCenters == null)
                    _pcrCenters = new Repository<PcrCenter>(_pcrContext);
                return _pcrCenters;
            }
        }

        public IRepository<TestCenterAvailability> TestCenterAvailabilities
        {
            get
            {
                if (_testCenterAvailabilities == null)
                    _testCenterAvailabilities = new Repository<TestCenterAvailability>(_pcrContext);
                return _testCenterAvailabilities;
            }
        }

        public IRepository<TestReport> TestReports
        {
            get
            {
                if (_testReports == null)
                    _testReports = new Repository<TestReport>(_pcrContext);
                return _testReports;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new Repository<User>(_pcrContext);
                return _users;
            }
        }


        public OperationResult Complete()
        {
            try
            {
                if (_pcrContext.SaveChanges() > 0)
                    return new OperationResult { Status = OperationStatus.Success };
                else
                    return new OperationResult { Status = OperationStatus.Ok, Message = "No rows are affected" };
            }
            catch (Exception ex)
            {
                return new OperationResult { Status = OperationStatus.Exception, Exception = ex, Message = ex.Message };
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
