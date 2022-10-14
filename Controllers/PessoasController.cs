using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using funcionadenovo.Data;
using funcionadenovo.Models;

namespace funcionadenovo.Controllers
{
    public class PessoasController : Controller
    {
        private readonly PessoaContexto _context;

        public PessoasController(PessoaContexto context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            var model = new Tabela
            {
                Pessoas = await _context.Pessoas.ToListAsync(),
                Produtos = await _context.Produtos.ToListAsync()
            };
            return View(model);
            //return View(await _context.Pessoas.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.id == id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return View(pessoas);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,idade,naosei")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,idade,naosei")] Pessoas pessoas)
        {
            if (id != pessoas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoasExists(pessoas.id))
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
            return View(pessoas);
        }

        public async Task<IActionResult> Edit2(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtos= await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }
            return View(produtos);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(String codigo, [Bind("codigo, nome, descricao")] Produtos produto)
        {
            if (codigo != produto.codigo){  return NotFound();}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosExists(produto.codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Index", "Home");
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2Manual(String codigo, [Bind("codigo, nome, descricao")] Produtos produto)
        {
            if (codigo != produto.codigo) { return NotFound(); }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosExists(produto.codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Index", "Home");
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Pessoas/Details/5
        //public async Task<IActionResult> Details2(string codigo)
        //[Route("Pessoas/Pessoas/Pessoas/Pessoas/Pessoas/Pessoas/Pessoas/Pessoas/Details2/{codigo?}", Name = "Pessoa-Details")]
        [Route("Pessoas/Details2/{codigo?}")]
        public async Task<IActionResult> Details2([FromRoute] string codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.codigo == codigo);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [Route("Pessoas/naosei/id1/{id1?}/id2/{id2?}", Name ="naointeressa")]
        public async Task<IActionResult> naosei([FromRoute] string id1, [FromRoute] string id2)
        {
            return Ok(Json(new { id1, id2}));
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoas = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.id == id);
            if (pessoas == null)
            {
                return NotFound();
            }

            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoasExists(int id)
        {
            return _context.Pessoas.Any(e => e.id == id);
        }

        private bool ProdutosExists(string codigo)
        {
            return _context.Produtos.Any(e => e.codigo == codigo);
        }

    }
}
