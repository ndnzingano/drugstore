using drugstore.Data;
using drugstore.Models;
using drugstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drugstore.Controllers
{
    public class LabsController : Controller
    {

        private readonly drugstoreContext _context;

        /*Cria uma propriedade referenciando um objeto de conexão com o banco*/
        /*Injeção de dependência, sõ vai criar uma instância do controller se tiver
         * um objeto de conexão com o banco como parâmetro*/
        public LabsController(drugstoreContext context)
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
            var list = _context.Lab.ToList();

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
            //var list = _context.Lab.Include(seller => lab.Department).Where(s => s.BirthDate > new DateTime(1998, 4, 20)).OrderBy(s => s.Name).ThenBy(s => s.Salary).ToList();


            return View(list);
        }

        //Será chamada essa action, quando o usuário acessar a rota /Sellers/Create 
        public IActionResult Create()
        {
    
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lab lab)
        {
            //Vamos atribuir o primeiro departamento do banco ao vendedor
            //seller.Medicine = _context.Medicine.FirstOrDefault();

            //Adiciona o vendedor ao banco
            _context.Lab.Add(lab);

            //Confirma a persistencia dos dados
            _context.SaveChanges();

            //Redireciona para o Index
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            //verificar se foi informado um ID na rota
            if (id == null)
            {
                return NotFound();
            }

            //Retorna o vendedor com o ID informado na rota
            //var lab = _context.Lab.FirstOrDefault(lab => lab.Id == id);
            var lab = _context.Lab.FirstOrDefault(lab => lab.Id == id);

            //Verifica se o vendedor existe
            if (lab == null)
            {
                return NotFound(nameof(lab));
            }

            return View(lab);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = _context.Lab.FirstOrDefault(lab => lab.Id == id);

            if (lab == null)
            {
                return NotFound(nameof(lab));
            }

            return View(lab);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var lab = _context.Lab.Find(id);

            if (lab == null)
            {
                return NotFound();
            }

            _context.Lab.Remove(lab);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            //busca vendedor no db
            Lab lab = _context.Lab.FirstOrDefault(s => s.Id == id);

            if (lab == null) return NotFound();

            //criar um vendedor com a lista de departamentos
            var viewModel = new MedicineFormViewModel();

            //adc lab no viewModel
            viewModel.Lab = lab;
            //adc o array de deps
            viewModel.Medicines = _context.Medicine.ToList();

            // passa viewmodel (lab + departments)
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Lab lab)
        {
            _context.Lab.Update(lab);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

     }


 }

