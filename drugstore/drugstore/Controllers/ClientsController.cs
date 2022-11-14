using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using drugstore.Data;
using drugstore.Models;

namespace drugstore.Controllers
{
    public class ClientsController : Controller
    {

        /*Cria uma propriedade referenciando um objeto de conexão com o banco*/
        private readonly drugstoreContext _context;

        /*Injeção de dependência, sõ vai criar uma instância do controller se tiver
         * um objeto de conexão com o banco como parâmetro*/
        public ClientsController(drugstoreContext context)
        {
            _context = context;
        }

        //A Interface espera uma View como retorno
        public IActionResult Index()
        {
            /*estamos pegando os dados da tabela Seller e adicionando a uma lista,
             * é a mesma coisa que List<Seller> list = new List<Seller>();
             */

            // Sem filtro
            var list = _context.Client.ToList();
            //var list = _context.Seller.Include(seller => seller.Department).ToList();
            //Com filtro usando o "Where" vendedores iniciam com A -> case sensitive
            //var list = _context.Seller.Include(seller => seller.Department).Where(s => s.Name.StartsWith("A")).ToList();

            // Where traz os vendedores que terminam com a letra A
            // var list = _context.Seller.Include(seller => seller.Department).Where(s => s.Name.EndsWith("a")).ToList();

            // Where traz os vendedores que contem "an"
            //var list = _context.Seller.Include(seller => seller.Department).Where(s => s.Name.Contains("an")).ToList();


            //// Where traz os vendedores com o salário superior a 2000
            //var list = _context.Seller.Include(seller => seller.Department).Where(s => s.Salary > 25000).ToList();

            //// Where traz os vendedores com nome = ao where
            //var list = _context.Seller.Include(seller => seller.Department).Where(s => s.Name == "Ana").ToList();

            // Retorna ordenado em ordem alfabética e salário
            //var list = _context.Seller.Include(seller => seller.Department).OrderBy(s => s.Name).ThenBy(s => s.Salary).ToList();


            // Retorna ordenado em ordem alfabética e salário
            //var list = _context.Client.Include(seller => seller.Department).Where(s => s.BirthDate > new DateTime(1998, 4, 20)).OrderBy(s => s.Name).ThenBy(s => s.Salary).ToList();


            return View(list);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Telephone,Address")] Client client)
        {
            //Vamos atribuir o primeiro departamento do banco ao vendedor
            //seller.Department = _context.Department.FirstOrDefault();

            //Adiciona o vendedor ao banco
            _context.Client.Add(client);

            //Confirma a persistencia dos dados
            _context.SaveChanges();

            //Redireciona para o Index
            return RedirectToAction("Index");
        }


        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Telephone,Address")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Client.FindAsync(id);
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
