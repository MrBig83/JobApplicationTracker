# 💼 Job Application Tracker
Ett C#-konsolprogram för att hålla koll på jobbansökningar med **LINQ**, **färger** och **objektorienterad struktur**.  
Utvecklat som en del av kursmomentet *Objektorienterad programmering & LINQ*.

---

## 🎯 Syfte
Syftet med projektet är att visa förståelse för:
- Objektorienterad programmering (klasser, objekt, metoder, enum)
- LINQ för filtrering, sortering och beräkningar
- Hantering av listor och nullable-värden
- Versionshantering i Git & GitHub (branches, commits, PRs)

---

## ⚙️ Funktionalitet
Programmet låter användaren:
- ➕ **Lägga till nya jobbansökningar**
- 📋 **Visa alla ansökningar** (färgkodade statusar)
- ✏️ **Uppdatera status** (Applied → Interview → Offer → Rejected)
- 🔍 **Filtrera efter status** *(LINQ Where + GroupBy)*
- 📅 **Sortera efter datum** *(OrderBy)*
- 📊 **Visa statistik** *(Count, Average, GroupBy)*
- ⏰ **Visa ansökningar utan svar äldre än 14 dagar** *(VG-bonus)*
- 🗑️ **Ta bort ansökningar**
- 💾 **Avsluta programmet**

---

## 🧩 Klasser och struktur

### 🧱 `JobApplication`
Representerar en enskild ansökan.  
Attribut:
- `CompanyName` – företagets namn  
- `PositionTitle` – tjänst/roll  
- `Status` – enum: `Applied`, `Interview`, `Offer`, `Rejected`  
- `ApplicationDate` – datum då ansökan skickades  
- `ResponseDate` – datum då svar mottogs (nullable)  
- `SalaryExpectation` – löneanspråk  

Metoder:
- `GetDaysSinceApplied()` – antal dagar sedan ansökan skickades  
- `GetSummary()` – sammanfattning av ansökan  

---

### 🧠 `JobManager`
Hanterar listan av ansökningar.

Metoder:
- `AddJob()` – lägger till ny ansökan  
- `UpdateStatus()` – ändrar status och sparar datum  
- `ShowAll()` – visar alla ansökningar  
- `ShowByStatus()` – filtrerar efter status (LINQ Where + GroupBy)  
- `ShowStatistics()` – visar statistik med LINQ (Count, Average, OrderBy)  
- `ShowUnansweredOver14Days()` – visar obesvarade äldre än 14 dagar *(VG-bonus)*  

---

### 🎨 `ColorHelper`
Hjälpklass som färglägger status:
| Status | Färg |
|:-------|:------|
| Applied | Gul |
| Interview | Cyan |
| Offer | Grön |
| Rejected | Röd |

---

## 🧮 LINQ-användning
Minst tre LINQ-operationer används:
```csharp
Applications.Where(a => a.Status == Status.Interview);
Applications.OrderBy(a => a.ApplicationDate);
Applications.GroupBy(a => a.Status);
Applications.Average(a => (a.ResponseDate - a.ApplicationDate)?.TotalDays);
