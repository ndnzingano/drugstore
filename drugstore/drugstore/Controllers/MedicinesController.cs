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
    public class MedicinesController : Controller
    {
        private readonly drugstoreContext _context;

        /*Injeção de dependência, sõ vai criar uma instância do controller se tiver
         * um objeto de conexão com o banco como parâmetro*/
        public MedicinesController(drugstoreContext context)
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
            var list = _context.Medicine.Include(medicine => medicine.Lab).ToList();

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
            //var list = _context.Medicine.Include(medicine => medicine.Lab).Where(s => s.BirthDate > new DateTime(1998, 4, 20)).OrderBy(s => s.Name).ThenBy(s => s.Salary).ToList();


            return View(list);
        }

        //Será chamada essa action, quando o usuário acessar a rota /Sellers/Create 
        public IActionResult Create()
        {
            //Criar uma instancia do nosso ViewModel
            var viewModel = new MedicineFormViewModel();

            //Acessar o banco de dados e retornar todos os registros de departamentos, adicionando eles nas lista de departamentos do ViewModel
            viewModel.Labs = _context.Lab.ToList();

            //Encaminhar a ViewModel com as informações para compilar a view(html)
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Medicine medicine)
        {
            //Vamos atribuir o primeiro departamento do banco ao vendedor
            //seller.Department = _context.Department.FirstOrDefault();

            //Adiciona o vendedor ao banco
            _context.Medicine.Add(medicine);

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
            //var seller = _context.Seller.FirstOrDefault(seller => seller.Id == id);
            var medicine = _context.Medicine.Include(medicine => medicine.Lab).FirstOrDefault(medicine => medicine.Id == id);

            //Verifica se o vendedor existe
            if (medicine == null)
            {
                return NotFound(nameof(medicine));
            }

            return View(medicine);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = _context.Medicine.Include(medicine => medicine.Lab).FirstOrDefault(medicine => medicine.Id == id);

            if (medicine == null)
            {
                return NotFound(nameof(medicine));
            }

            return View(medicine);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var medicine = _context.Medicine.Find(id);

            if (medicine == null)
            {
                return NotFound();
            }

            _context.Medicine.Remove(medicine);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            //busca vendedor no db
            Medicine medicine = _context.Medicine.Include(medicine => medicine.Lab).FirstOrDefault(medicine => medicine.Id == id);

            if (medicine == null) return NotFound();

            //criar um vendedor com a lista de departamentos
            var viewModel = new MedicineFormViewModel();

            //adc seller no viewModel
            viewModel.Medicine = medicine;
            //adc o array de deps
            viewModel.Labs = _context.Lab.ToList();

            // passa viewmodel (seller + departments)
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(Medicine medicine)
        {
            _context.Medicine.Update(medicine);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
