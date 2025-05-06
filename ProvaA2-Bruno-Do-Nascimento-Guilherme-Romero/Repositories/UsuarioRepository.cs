using System;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Repositories;

public class UsuarioRepository 
{
    private readonly ApplicationDbContext _banco;
    public UsuarioRepository(ApplicationDbContext banco)
    {
        _banco = banco;
    }
    public Usuario? BuscarUsuarioPorEmailSenha(string email, string senha)
    {
        Usuario? usuario = _banco.Usuarios.FirstOrDefault
            (x => x.email == email && x.senha == senha);
        return usuario;
    }

    public void Cadastrar(Usuario usuario)
    {
        _banco.Usuarios.Add(usuario);
        _banco.SaveChanges();
    }

    public List<Usuario> Listar()
    {
        return _banco.Usuarios.ToList();
    }
}