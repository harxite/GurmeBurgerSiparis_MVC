﻿using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WA_HamburgerProjesiMVC_100124.Models;

namespace WA_HamburgerProjesiMVC_100124.Controllers
{
	[Authorize(Roles ="admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<AppUser> userManager;

		public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
			this.roleManager = roleManager;
			this.userManager = userManager;
		}
        public IActionResult Index()
		{
			return View(roleManager.Roles);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Required]string name)
		{
			if (ModelState.IsValid)
			{
				IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					Errors(result);
				}
			}

			return View(name);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			IdentityRole role = await roleManager.FindByIdAsync(id);

			if (role != null)
			{
				IdentityResult result = await roleManager.DeleteAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}
				else
				{
					Errors(result);
				}
			}
			else
			{
				ModelState.AddModelError("", "Role Not Found");
			}

			return View("Index", roleManager.Roles);
		}


		public async Task<IActionResult> Update(string id)
		{
			IdentityRole role = await roleManager.FindByIdAsync(id);

			List<AppUser> members = new List<AppUser>();

			List<AppUser> nonMembers = new List<AppUser>();

			foreach (AppUser user in userManager.Users)
			{
				var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
				list.Add(user);
			}

			return View(new RoleEditVM
			{
				Role = role,
				Members = members,
				NonMembers = nonMembers
			});
		}

		[HttpPost]
		public async Task<IActionResult> Update(RoleModificationVM model)
		{
			IdentityResult result;

			if (ModelState.IsValid)
			{
				foreach (string userId in model.AddIds ?? new string[] {})
				{
					AppUser user = await userManager.FindByIdAsync(userId);

					if (user != null)
					{
						result = await userManager.AddToRoleAsync(user, model.RoleName);
						if (!result.Succeeded) 
						{
							Errors(result);
						}
					}
				}

				foreach (string userId in model.DeleteIds ?? new string[] {})
				{
					AppUser user = await userManager.FindByIdAsync(userId);

					if (user != null)
					{
						result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
						if (!result.Succeeded)
						{
							Errors(result);
						}
					}
				}
			}

			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return await Update(model.RoleId);
			}
		}

		private void Errors(IdentityResult result)
		{
			foreach (IdentityError item in result.Errors)
			{
				ModelState.AddModelError("UpdateUser", $"{item.Code} - {item.Description}");
			}
		}
	}
}
