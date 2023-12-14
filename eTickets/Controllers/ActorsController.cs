using eTickets.Data;
using eTickets.Data.Sevices;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)

        {
            Console.WriteLine(actor.Id);
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var modelStateEntry = ModelState[key];

                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine($"Validation error for property '{key}': {error.ErrorMessage}");
                    }
                }
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorEdit = await _service.GetByIdAsync(id);
            if (actorEdit == null) return View("NotFound");
            return View(actorEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)

        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDelete = await _service.GetByIdAsync(id);
            if (actorDelete == null) return View("NotFound");
            return View(actorDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDelete = await _service.GetByIdAsync(id);
            if (actorDelete == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}