using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redson_backend.DataAccess;
using Redson_backend.Models;
using Microsoft.AspNetCore.Authorization;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp;

namespace Redson_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController : GenericC
    {

        public OrdersController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
            this.entityType = "Order";
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return (List<Order>)GetAllEntities();
        }

        [HttpGet("{id}")]
        public Order Details(int id)
        {
            var order = (Order)GetEntity(id);

            return this.LoadRelationship(order);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order entity)
        {
            return CreateEntity(entity);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Order entity)
        {
            return UpdateEntity(entity);
        }

        protected Order LoadRelationship(Order order)
        {
            try
            {
                if (order == null)
                {
                    return order;
                }

                var context = _dataAccessProvider.GetContext();
                if (order.OrganizationId != null)
                {
                    order.Organization = context.organization.FirstOrDefault(t => t.Id == order.OrganizationId);
                }

                if (order.VehicleId != null)
                {
                    order.Vehicle = context.vehicle.FirstOrDefault(t => t.Id == order.VehicleId);
                }

                if (order.OwnerId != null)
                {
                    order.Owner = context.user.FirstOrDefault(t => t.Id == order.OwnerId);
                }

                if (order.TechnicianId != null)
                {
                    order.Technician = context.user.FirstOrDefault(t => t.Id == order.TechnicianId);
                }

                if (order.AccountId != null)
                {
                    order.Account = context.account.FirstOrDefault(t => t.Id == order.AccountId);
                }

                if (order.LocationId != null)
                {
                    order.Location = context.location.FirstOrDefault(t => t.Id == order.LocationId);
                }

                if (order.ParentOrderId != null)
                {
                    order.ParentOrder = context.order.FirstOrDefault(t => t.Id == order.ParentOrderId);
                }

                return order;
            }
            catch (Exception)
            {
                Response.StatusCode = 401;
                return null;
                throw;
            }

            
        }

        
        [HttpGet("{OrderId}")]
        public IActionResult GetPDF()
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PageSize.A4);
            pdf.Save("document.pdf");
            return Ok();
        }
    }
}
