﻿using Fenicia.Application.UseCases.Users.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenicia.Application.Common.Interfaces.UseCases.Users
{
    public interface IRegisterUserInteractor: IRequestHandlerInteractor<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
