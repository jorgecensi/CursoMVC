﻿namespace JLC.CursoMVC.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();
    }
}
