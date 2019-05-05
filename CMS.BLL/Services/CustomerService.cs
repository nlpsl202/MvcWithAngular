using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL;
using CMS.DAL.Repository;
using CMS.Domain;
using CMS.DAL.Interfaces;
using CMS.Domain.ViewModels;
using AutoMapper;

namespace CMS.BLL.Services
{
    public class CustomerService
    {
        private IRepository<Customers> db;

        public CustomerService()
        {
            db = new GenericRepository<Customers>();
        }

        public List<CustomerViewModel> Get()
        {
            var DbResult = db.Get().ToList(); ;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customers, CustomerViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<Customers>, List<CustomerViewModel>>(DbResult);

            /*List<CustomerViewModel> model = new List<CustomerViewModel>();
            foreach(var item in DbResult)
            {
                CustomerViewModel _model = new CustomerViewModel();
                _model.CustomerID = item.CustomerID;
                _model.ContactName = item.ContactName;
                model.Add(_model);
            }
            return model.AsQueryable();*/
        }
    }
}
