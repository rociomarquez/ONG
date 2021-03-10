﻿using ONG.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ONG.WebAdmin.Controllers
{
    public class OrdenesController : Controller
    {
        OrdenesBL _ordenesBL;
        BeneficiariosBL _beneficiariosBL;

        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
            _beneficiariosBL = new BeneficiariosBL();        
        }

        // GET: Ordenes
        public ActionResult Index()
        {

            var listadeOrdenes = _ordenesBL.ObtenerOrdenes();
            return View(listadeOrdenes);
        }

        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            var beneficiarios = _beneficiariosBL.ObtenerBeneficiarios();

            ViewBag.BeneficiariosId = new SelectList(beneficiarios, "Id", "Nombre");

            return View(nuevaOrden);
        }

        [HttpPost]
        public ActionResult Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                if (orden.BeneficiarioId == 0)
                {
                    ModelState.AddModelError("BeneficiarioId", "Seleccione un beneficiario");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);

                return RedirectToAction("Index");


            }
            var beneficiario = _beneficiariosBL.ObtenerBeneficiarios();

            ViewBag.BeneficiariosId = new SelectList(beneficiario, "Id", "Nombre");

            return View(orden); 

        }
    }
}