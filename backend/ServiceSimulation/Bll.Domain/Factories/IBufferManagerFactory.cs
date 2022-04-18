﻿using Bll.Domain.Interfaces;

namespace Bll.Domain.Factories;

public interface IBufferManagerFactory
{
    IBufferManager CreateBufferManager();
}