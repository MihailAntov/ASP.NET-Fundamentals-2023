﻿using ChatApp.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
	public class ChatController : Controller
	{
		private static List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();
		[HttpGet]
		public IActionResult Show()
		{
			if(!messages.Any())
			{
				return View(new ChatViewModel());
			}

			var chatModel = new ChatViewModel()
			{
				Messages = messages.Select(m =>
				new MessageViewModel()
				{
					Sender = m.Key,
					Message = m.Value

				}).ToList()
			};
			return View(chatModel);
		}

		[HttpPost]
		public IActionResult Send(ChatViewModel chat)
		{
			if(string.IsNullOrWhiteSpace(chat.CurrentMessage.Message) || string.IsNullOrWhiteSpace(chat.CurrentMessage.Sender))
			{
				return RedirectToAction("Show");
			}
			MessageViewModel newMessage = chat.CurrentMessage;
			messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message));
			return RedirectToAction("Show");
		}
	}
}
