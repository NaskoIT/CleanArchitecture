using Blog.Application.Common.Interfaces;
using System;

namespace Blog.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
