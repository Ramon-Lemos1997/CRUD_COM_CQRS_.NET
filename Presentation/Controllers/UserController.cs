using CQRS.Commands.User;
using CQRS.Queries.User;
using Domain.Entities.User;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_COM_CQRS.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //-----------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new QueryAllUser());
            return View(result);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _mediator.Send(new QueryUserById(id));
            var userModel = ConvertToUserModel(result);
            return View(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new QueryUserById(id));
            var userModel = ConvertToUserModel(result);
            return View(userModel);
        }

        //-----------------------------------------------------------------------------

        [HttpPost]
        public async Task<IActionResult> Update(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var result = await _mediator.Send(new UpdateUserCommand(userModel.Id, userModel.BusinessName, userModel.CnpjNumber, userModel.Role, userModel.Email, userModel.WhatsApp));

            if (result.HasError)
            {
                ModelState.AddModelError(result.Key, result.Content);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("Dados inválidos", "Usuário não encontrado");
                return View();
            }

            var result = await _mediator.Send(new DeleteUserCommand(id));

            if (result.HasError)
            {
                ModelState.AddModelError(result.Key, result.Content);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var result = await _mediator.Send(new CreateUserCommand(userModel.BusinessName, userModel.CnpjNumber, userModel.Role, userModel.Email, userModel.WhatsApp));

            if (result.HasError)
            {
                ModelState.AddModelError(result.Key, result.Content);
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        //-----------------------------------------------------------------------------

        private UserModel ConvertToUserModel(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                BusinessName = user.BusinessName,
                CnpjNumber = user.CnpjNumber,
                Role = user.Role,
                Email = user.Email,
                WhatsApp = user.WhatsApp
            };
        }

        //-------------------------------------------------------------------------
    }
}