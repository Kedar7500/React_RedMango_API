using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Data;
using RedMango_API.Models.DTO;
using RedMango_API.Repository;

namespace RedMango_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepository itemRepository;
        private readonly IMapper mapper;
        private readonly ILogger<MenuItemsController> logger;

        public MenuItemsController(IMenuItemRepository itemRepository, IMapper mapper,
           ILogger<MenuItemsController> logger )
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET : https://localhost:7164/api/MenuItems
        // Get all menu items
        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            try
            {
                // getting all menuitems
                var menuItems = await itemRepository.GetMenuItems();

                // mapping domainn to dto
                var menuItemsDto = mapper.Map<List<MenuItemDto>>(menuItems);

                // returning success response
                return Ok(menuItemsDto);

            }
            catch (Exception e)
            {
                logger.LogError("In GetAllMenuItems : "+e.Message);
                return NotFound();
            }
           
        }
    }
}
