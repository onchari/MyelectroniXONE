using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Models
{
    interface IActionModelling
    {
        ActionResult Index();
        ActionResult Details(int? id);
        ActionResult Create();
        ActionResult Create( Object modelClassEntity);
        ActionResult Edit(int? id);
        ActionResult Edit([Bind(Include = "")] Object modelClassEntity);
        ActionResult Delete(int? id);
        ActionResult DeleteConfirmed(int id);
       

    }
}