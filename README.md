# Prova Prática .NET (MVC + API + Oracle EF Core)

Solução contendo **2 projetos**:
- **api/**: ASP.NET Core Web API com EF Core (Oracle) e Swagger.
- **mvc/**: ASP.NET Core MVC que consome a API via `HttpClient`.

## Como usar (passos rápidos)
1. Ajuste a string de conexão do Oracle em `api/appsettings.json` (chave `OracleConnection`).
2. Na API, rode as migrations (exemplo): `dotnet ef migrations add Init && dotnet ef database update`.
3. `dotnet run` em `api/` para subir o Swagger.
4. Em `mvc/appsettings.json`, configure a `ApiBaseUrl` para apontar para a porta da API (ex.: `http://localhost:5274`).
5. `dotnet run` em `mvc/` para usar as telas.

> **Tema usado:** Imobiliária (Locação/Venda) — por inicial **L**.  
> Entidades: `Cliente`, `Produto`, `Usuario (Login)`, `Imovel`, `Contrato`.

## Regras implementadas (exemplos)
- SKU de Produto deve ser único.
- Não permitir estoque negativo ao criar/atualizar Produto.
- Um `Contrato` ativo bloqueia alteração do `Imovel` relacionado.

## Evidências (preencher)
- **Dupla**: (Nome 1 – RM; Nome 2 – RM)
- **RM nas tabelas**: adicione colunas `CriadoPorRM`/`AtualizadoPorRM` se desejar evidenciar no banco, ou descreva aqui quem fez o quê.

---
