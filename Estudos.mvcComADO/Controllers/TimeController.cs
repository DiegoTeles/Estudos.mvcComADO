using Estudos.mvcComADO.Repository;
using System;
using System.Web.Mvc;
using Estudos.MvcComADO.Models;

namespace Estudos.mvcComADO.Controllers
{
    public class TimeController : Controller
    {

        private TimeRepository _repository;

        [HttpGet]
        public ActionResult ObterTimes()
        {
            _repository = new TimeRepository();

            ModelState.Clear();
            return View(_repository.ObterTimes());
        }
        [HttpGet]
        public ActionResult IncluirTime()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IncluirTime(Times timeObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository = new TimeRepository();
                    if (_repository.AdicionarTime(timeObj))
                    {
                        ViewBag.Mensagem = "Time Cadastrado com Sucesso!";
                    }
                }
                return View ();
            }
            catch (Exception)
            {

                return View("ObterTimes");
            }

        }

        public ActionResult EditarTime(int id)
        {
            _repository = new TimeRepository();

            return View(_repository.ObterTimes().Find(x=>x.ID_Time == id));
        }
        [HttpPost]
        public ActionResult EditarTime(int  id, Times timeObj)
        {
            try
            { 
                    _repository = new TimeRepository();
                _repository.AtualizarTime(timeObj);
                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {

                return View("ObterTimes");
            }

        }
        public ActionResult ExcluirTime(int id)
        {
            try
            {
                _repository = new TimeRepository();
                if (_repository.ExcluirTime(id))
                {
                    ViewBag.Mensagem = "Time Excluido com Sucesso!";
                }

                return RedirectToAction("ObterTimes");

            }
            catch (Exception)
            {

                return View("ObterTimes");
            }
        }
    }

}