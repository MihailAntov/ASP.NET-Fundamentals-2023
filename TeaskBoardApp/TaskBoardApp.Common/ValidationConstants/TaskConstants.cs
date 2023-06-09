using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardApp.Common.ValidationConstants
{
    public static class TaskConstants
    {
        public const int TaskTitleMinLength = 5;
        public const int TaskTitleMaxLength = 70;
        public const int TaskDescriptionMinLength = 10;
        public const int TaskDescriptionMaxLength = 1000;
    }
}
