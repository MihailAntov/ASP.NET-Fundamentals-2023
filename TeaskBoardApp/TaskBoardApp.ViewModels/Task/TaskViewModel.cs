﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.ViewModels.Task
{
    public class TaskViewModel
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Description { get; init; } = null!;
        public string Owner { get; init; } = null!;
    }
}
