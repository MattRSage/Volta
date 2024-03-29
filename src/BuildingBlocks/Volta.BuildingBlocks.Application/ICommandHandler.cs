﻿using MediatR;

namespace Volta.BuildingBlocks.Application
{
    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {

    }
}