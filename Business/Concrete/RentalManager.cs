using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Business.BusinessRules;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal productDal)
        {
            _rentalDal = productDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [TransactionScopeAspect]
        [PerformanceAspect(interval: 13)]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfRentalAccessible(rental));
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            return new SuccessResult(result.Message);
           
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [TransactionScopeAspect]
        [PerformanceAspect(interval: 5)]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect()]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [PerformanceAspect(interval: 5)]
        [CacheAspect(duration: 5)]
        public IDataResult<Rental> GetRentalById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id), Messages.RentalFound);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult CheckIfRentalAccessible(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate != null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.ReturnDate);
            }
            return new SuccessResult(Messages.RentalAdded);
        }
    }
}
