using Blog.Application.Common.Services;
using System;

namespace Blog.Application.Common.Interfaces
{
    public interface IDateTime : ITransientService
    {
        DateTime Now { get; }
    }
}
