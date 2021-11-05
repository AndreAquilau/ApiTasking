using ApiTasking.Data;
using ApiTasking.Data.DTOs;
using ApiTasking.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiTasking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskingController : ControllerBase
    {
        private IMapper _mapper;
        private TaskingContext _context;

        public TaskingController(TaskingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                var task = _context.Taskings;

                return Ok(task);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            try
            {
                var task = _context.Taskings?.Where(item => item.Id == id).FirstOrDefault();

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTasking(int id)
        {
            try
            {
                var task = _context.Taskings?.Where(item => item.Id == id).FirstOrDefault();

                if (task == null)
                {
                    return NotFound();
                }

                _context.Taskings?.Remove(task);

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult CreateTasking([FromBody] TaskingCreateDto taskingCreateDto) { 
            try {
                var task = _mapper.Map<Tasking>(taskingCreateDto);
                    
                var result =_context.Taskings?.Add(task);

                _context.SaveChanges();

                return Ok();
            } catch(Exception ex) {
              return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTasking([FromBody] TaskingUpdateDto taskingUpdateDto, int id)
        {
            try
            {
                var task = _context.Taskings?.Where(item => item.Id == id).FirstOrDefault();

                if(task == null)
                {
                    return NotFound();
                }

                _mapper.Map(taskingUpdateDto, task);

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
