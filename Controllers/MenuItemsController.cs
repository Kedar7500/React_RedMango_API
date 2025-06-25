using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Data;
using RedMango_API.Models.Domain;
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

                if(menuItems == null)
                {
                    return NotFound();
                }

                // mapping domainn to dto
                var menuItemsDto = mapper.Map<List<MenuItemDto>>(menuItems);

                // returning success response
                return Ok(menuItemsDto);

            }
            catch (Exception e)
            {
                logger.LogError("In GetAllMenuItems : "+e.Message);
                return StatusCode(500, "An unexpected error occurred.");
            }
           
        }

        // GET :  https://localhost:7164/api/MenuItems/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                // Get menuItem by Id
                var menuItemDomain = await itemRepository.GetMenuItem(id);

                if(menuItemDomain == null)
                {
                    return NotFound();
                }

                // mapping from domain to dto
                var menuItemDto = mapper.Map<MenuItemDto>(menuItemDomain);

                return Ok(menuItemDto);


            }
            catch (Exception e)
            {
                logger.LogError($"In GetById : {e.Message}");
                return StatusCode(500, e.Message);
               
            }
        }

        // POST : https://localhost:7164/api/MenuItems
        [HttpPost]
        public async Task<IActionResult> CreateMenuItem([FromBody] AddMenuItemDto addMenuItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // mapp addItemDto to menuItemDomain
                    var menuItemDomain = mapper.Map<MenuItem>(addMenuItem);

                    // add menuitem to db 
                    menuItemDomain = await itemRepository.CreateMenuItem(menuItemDomain);

                    // map domain to dto
                    var menuItemDto = mapper.Map<MenuItemDto>(menuItemDomain);

                    return CreatedAtAction(nameof(GetById), new { id = menuItemDomain.Id }, menuItemDto);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                logger.LogError($"In CreateMenuItem : {e.Message}");
                return StatusCode(500, "An unexpected error occurred.");

            }
        }

        // PUT :  https://localhost:7164/api/MenuItems/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateMenuItem([FromRoute] int id, [FromBody] UpdateMenuItemDto updateMenuItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // map updateMenuItemDto to menuItemDomain
                    var menuItem = mapper.Map<MenuItem>(updateMenuItem);

                    menuItem = await itemRepository.UpdateMenuItem(id, menuItem);

                    // map domain to dto 
                    var menuItemDto = mapper.Map<MenuItemDto>(menuItem);

                    return Ok(menuItemDto);
                }
                else
                {
                    return BadRequest();
                }
               
            }
            catch (Exception e)
            {
                logger.LogError($"In UpdateMenuItem: {e.Message}");
                return StatusCode(500, "unexpected error occured");
             
            }
        }

        // DELETE :  https://localhost:7164/api/MenuItems/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteMenuItem([FromRoute] int id)
        {
            try
            {
                var menuItem = await itemRepository.DeleteMenuItem(id);

                if(menuItem == null)
                {
                    return NotFound();
                }

                return Ok(menuItem);
            }
            catch (Exception e)
            {
                logger.LogError($"In DeleteMenuItem : {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}
