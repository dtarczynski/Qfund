﻿using Qfund.Domain.Transaction.Entities;

namespace Qfund.Application.Common.Interfaces.Persistence;

public interface ITransactionsRepository
{
    Task<IEnumerable<QfundTransaction>> GetAll(CancellationToken cancellationToken);

    void Add(
        QfundTransaction trans,
        CancellationToken cancellationToken = default);
}
