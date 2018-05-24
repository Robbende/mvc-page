using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books_MVC.Models;

namespace Books_MVC.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public List<Customer> CustomerOrders = new List<Customer>()
        {
            new Customer(){
                Id=1, 
                Name="alex", 
                ServiceLevel="normal", 
                Orders = new List<Order>() { 
                    new Order(){
                        Id=1,
                        OrderTime=DateTime.Now
                    }
                }
            },
            new Customer(){
                Id=2, 
                Name="ruben", 
                ServiceLevel="normal", 
                Orders = new List<Order>() { 
                    new Order(){
                        Id=2,
                        OrderTime=DateTime.Now.AddMinutes(1)
                    },
                    new Order(){
                        Id=3,
                        OrderTime=DateTime.Now.AddMinutes(2)
                    },
                    new Order(){
                        Id=3,
                        OrderTime=DateTime.Now.AddMinutes(3)
                    },
                }
            }
        };


        public ActionResult Index()
        {
            List<CustomerSummary> summary = new List<CustomerSummary>();

            foreach (Customer c in CustomerOrders)
            {
                List<Order> cus_order = c.Orders.OrderByDescending(i => i.OrderTime).ToList();

                string cus_name = c.Name;
                string cus_service = c.ServiceLevel;

                int cus_or_count = cus_order.Count;
                string cus_resent_ord = "";
                int cus_or_id = 0;

                if (cus_order.Count > 0)
                {
                    cus_resent_ord = cus_order[0].OrderTime.ToString();
                    cus_or_id = cus_order[0].Id;
                }


                summary.Add(new CustomerSummary()
                {
                    Name = cus_name,
                    ServiceLevel = cus_service,
                    MostRecentOrderDate = cus_resent_ord,
                    OrderCount = cus_or_count.ToString(),
                    Input = new CustomerSummary.CustomerSumaryInput()
                    {
                        Number = 0,
                        Active = false
                    }
                });
            }


            return View("IndexCustomers", summary);
        }

        public ActionResult ChangeStatus(List<CustomerSummary> input)
        {
            return View();
        }

    }
}
