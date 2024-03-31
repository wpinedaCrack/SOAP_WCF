﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pacagroup.Comercial.Creditos.Dominio;
using Pacagroup.Comercial.Creditos.ContratoRepositorio;
using Dapper;

namespace Pacagroup.Comercial.Creditos.SqlRepositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public Cliente ObtenerCliente(string numeroDocumento)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("pNumeroDocumento", numeroDocumento);

                var cliente = conexion.QuerySingle<Cliente>("dbo.sp_cliente_obtener", param: parametros,
                    commandType: CommandType.StoredProcedure);
                return  cliente;
            }
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var cliente = conexion.Query<Cliente>("dbo.sp_cliente_listar", commandType: CommandType.StoredProcedure);
                return cliente;
            }
        }

        public IEnumerable<Cliente> BuscarCliente(Cliente cliente)
        {
            using (IDbConnection conexion = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                conexion.Open();
                var parametros = new DynamicParameters();
                parametros.Add("ApellidoPaterno", cliente.ApellidoPaterno);
                var coleccionClientes = conexion.Query<Cliente>("dbo.sp_cliente_buscar", parametros, commandType: CommandType.StoredProcedure);
                return coleccionClientes;
            }
        }

    }
}
