namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using AutoMapper.QueryableExtensions;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                ItemsIds = 
                    this.context.Items.OrderBy(i => i.Id).Select(i => i.Id).ToArray(),

                ItemsNames = 
                    this.context.Items.OrderBy(i => i.Id).Select(x => x.Name).ToArray(),

                EmployeesIds = 
                    this.context.Employees.OrderBy(e => e.Id).Select(e => e.Id).ToArray(),

                EmployeesNames = 
                    this.context.Employees.OrderBy(e => e.Id).Select(x => x.Name).ToArray()
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        { 
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);
            order.DateTime = DateTime.Now;
            order.Type = (OrderType) Enum.Parse(typeof(OrderType), model.OrderType);

            order.OrderItems.Add(new OrderItem
            {
                OrderId = order.Id,
                ItemId = model.ItemId,
                Quantity = model.Quantity
            });            

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                .ProjectTo<OrderAllViewModel>(this.mapper.ConfigurationProvider)
                .ToArray();

            return this.View(orders);
        }
    }
}
