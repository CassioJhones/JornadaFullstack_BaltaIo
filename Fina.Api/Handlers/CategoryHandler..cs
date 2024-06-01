using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            Category category = new Category
            {
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category, 201, "Criada com Sucesso");
        }
        catch (Exception erro)
        {
            //recomendado Serilog, etc
            Console.WriteLine(erro.Message);
            return new Response<Category?>(null, 500, "Erro Fatal");

        }

    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            Category category = await context.Categories.
                FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null)
                return new Response<Category?>(null, 404, "Categoria Não Encontrada");

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Categoria Excluida com Sucesso");
        }
        catch (Exception erro)
        {
            Console.WriteLine(erro.Message);
            return new Response<Category?>(null, 404, "Categoria Nao Encontrada");

        }
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
    {
        try
        {
            IOrderedQueryable<Category> query = context.Categories.AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Title);

            List<Category> categories = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            int count = await query.CountAsync();
            return new PagedResponse<List<Category>?>(categories, count, request.PageNumber, request.PageSize);

        }
        catch (Exception erro)
        {
            Console.WriteLine(erro.Message);
            return new PagedResponse<List<Category>?>(null,404,"Erro");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        try
        {
            Category? category = await context.Categories.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            return category is null
                ? new Response<Category?>(null, 404, "Nao encontrado")
                : new Response<Category?>(category);
        }
        catch (Exception erro)
        {
            return new Response<Category?>(null, 404, "Categoria Nao Encontrada");
            Console.WriteLine(erro.Message);
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            Category category = await context.Categories.
                FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

            if (category is null)
                return new Response<Category?>(null, 404, "Categoria Nao Encontrada");

            category.Title = request.Title;
            category.Description = request.Description;

            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Atualizada com Sucesso");
        }
        catch (Exception erro)
        {
            Console.WriteLine(erro.Message);
            return new Response<Category?>(null, 404, "Categoria Nao Encontrada");

        }
    }
}
