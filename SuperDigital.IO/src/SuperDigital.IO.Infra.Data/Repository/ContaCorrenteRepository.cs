using Dapper;
using Microsoft.EntityFrameworkCore;
using SuperDigital.IO.Domain.ContaCorrente;
using SuperDigital.IO.Domain.ContaCorrente.Repository;
using SuperDigital.IO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDigital.IO.Infra.Data.Repository
{
    public class ContaCorrenteRepository : Repository<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(ContaCorrenteContext context) : base(context)
        {

        }

        public override IEnumerable<ContaCorrente> ObterTodos()
        {
            var sql = "SELECT * FROM tb_ContaCorrenteSuperDigital";

            return Db.Database.GetDbConnection().Query<ContaCorrente>(sql);
        }

        public override ContaCorrente ObterPorId(int id)
        {
            var sql = @"SELECT * FROM tb_ContaCorrenteSuperDigital " +
                "WHERE NumeroConta = @conta";

            var evento = Db.Database.GetDbConnection().Query<ContaCorrente>(sql, new { conta = id }
                );

            return evento.FirstOrDefault();
        }
    }
}
