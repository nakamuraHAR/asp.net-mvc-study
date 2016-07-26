using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PCInfoEditor.Models;

namespace PCInfoEditor.Controllers
{
    // [Authorize]属性をつけて、ログイン状態でないときに、PC管理画面に遷移しないように設定
    [Authorize]
    public class PCInfoesController : Controller
    {
        private PCInfoDBContext db = new PCInfoDBContext();

        // GET: PCInfoes
        public ActionResult Index(string serialNumber, string ipAddress, string useSegment, string machineType, string modelNumber, string userName, string pcName, string remark)
        {
            var useSegmentList = new List<UseSegment>();
            var useSegmentQuery = from d in db.PCInfos orderby d.UseSegment select d.UseSegment;
            useSegmentList.AddRange(useSegmentQuery.Distinct());
            ViewBag.useSegment = new SelectList(useSegmentList);

            var pcInfoes = from m in db.PCInfos select m;

            // PC管理番号の条件で抽出
            if (!string.IsNullOrEmpty(serialNumber))
            {
                pcInfoes = pcInfoes.Where(s => s.SerialNumber.Contains(serialNumber));
            }
            // IPアドレスの条件で抽出
            if (!string.IsNullOrEmpty(ipAddress))
            {
                pcInfoes = pcInfoes.Where(s => s.IPAddress.Contains(ipAddress));
            }
            // 使用区分の条件で抽出
            if (!string.IsNullOrEmpty(useSegment))
            {
                pcInfoes = pcInfoes.Where(s => s.UseSegment.ToString() == useSegment);
            }
            // 機種の条件で抽出
            if (!string.IsNullOrEmpty(machineType))
            {
                pcInfoes = pcInfoes.Where(s => s.MachineType.Contains(machineType));
            }
            // 型番の条件で抽出
            if (!string.IsNullOrEmpty(modelNumber))
            {
                pcInfoes = pcInfoes.Where(s => s.ModelNumber.Contains(modelNumber));
            }
            // 使用者名の条件で抽出
            if (!string.IsNullOrEmpty(userName))
            {
                pcInfoes = pcInfoes.Where(s => s.UserName.Contains(userName));
            }
            // PC名の条件で抽出
            if (!string.IsNullOrEmpty(pcName))
            {
                pcInfoes = pcInfoes.Where(s => s.PCName.Contains(pcName));
            }
            // 備考の条件で抽出
            if (!string.IsNullOrEmpty(remark))
            {
                pcInfoes = pcInfoes.Where(s => s.Remark.Contains(remark));
            }

            // 結果表示
            return View(pcInfoes);
        }

        // GET: PCInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCInfo pCInfo = db.PCInfos.Find(id);
            if (pCInfo == null)
            {
                return HttpNotFound();
            }
            return View(pCInfo);
        }

        // GET: PCInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PCInfoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SerialNumber,IPAddress,UseSegment,MachineType,ModelNumber,UserName,PCName,Remark")] PCInfo pCInfo)
        {
            if (ModelState.IsValid)
            {
                db.PCInfos.Add(pCInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pCInfo);
        }

        // GET: PCInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCInfo pCInfo = db.PCInfos.Find(id);
            if (pCInfo == null)
            {
                return HttpNotFound();
            }
            return View(pCInfo);
        }

        // POST: PCInfoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SerialNumber,IPAddress,UseSegment,MachineType,ModelNumber,UserName,PCName,Remark")] PCInfo pCInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pCInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pCInfo);
        }

        // GET: PCInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCInfo pCInfo = db.PCInfos.Find(id);
            if (pCInfo == null)
            {
                return HttpNotFound();
            }
            return View(pCInfo);
        }

        // POST: PCInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PCInfo pCInfo = db.PCInfos.Find(id);
            db.PCInfos.Remove(pCInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
