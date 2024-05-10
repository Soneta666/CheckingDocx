//using DocumentFormat.OpenXml.Drawing;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace CheckingDocx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckingController : ControllerBase
    {
        [HttpPost("getSize")]
        public async Task<IActionResult> GetSize(IFormFile file)
        {
            try
            {
                List<string?> sizes = Sizes(file);


                //using (DocX doc = DocX.Load(file))

                // Отримання всіх абзаців документу
                //    var paragraphs = doc.Paragraphs;

                //    // Проходження по кожному абзаці
                //    foreach (var paragraph in paragraphs)
                //    {
                //        // Отримання всіх рядків у поточному абзаці
                //        //var runs = paragraph.Runs;

                //        // Проходження по кожному рядку
                //        //foreach (var run in runs)
                //        //{
                //        // Отримання розміру шрифту для поточного рядка
                //        var fontSize1 = paragraph.FontSize(10);

                //            // Перевірка, чи розмір шрифту не дорівнює нулю


                //    }
                //}
                ////using (var stream = file.OpenReadStream())
                ////{
                //using (var memoryStream = new MemoryStream())
                //{
                //    // Копіюємо вміст файлу у пам'ять
                //    await file.CopyToAsync(memoryStream);
                //    memoryStream.Position = 0;
                //    string fileName = file.Name;

                // Відкриваємо WordprocessingDocument з MemoryStream



                if (sizes != null)
                {
                    return Ok(sizes);
                }
                else
                {
                    return BadRequest("Розмір шрифту не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingSize")]
        public async Task<IActionResult> CheckingSize(IFormFile file, [FromForm] string fontSize)
        {
            try
            {
                List<string?> sizes = Sizes(file);

                if (sizes != null)
                {
                    int tmp = sizes.FindAll(f => f == fontSize).Count;
                    if (tmp == sizes.Count)
                        return Ok("Є тільки цей стиль");
                    else
                        return Ok("Є ще інші стилі");
                }
                else
                {
                    return BadRequest("Шрифт не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        
        [HttpPost("getFontFamily")]
        public async Task<IActionResult> GetFontFamily(IFormFile file)
        {
            try
            {
                List<string?> fontFamilies = Families(file);

                if (fontFamilies != null)
                {
                    return Ok(fontFamilies);
                }
                else
                {
                    return BadRequest("Шрифт не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingFontFamily")]
        public async Task<IActionResult> CheckingFontFamily(IFormFile file, [FromForm]string fontFamily)
        {
            try
            {
                List<string?> fontFamilies = Families(file);

                if (fontFamilies != null)
                {
                    int tmp = fontFamilies.FindAll(f => f == fontFamily).Count;
                    if (tmp == fontFamilies.Count)
                        return Ok("Є тільки цей стиль");
                    else
                        return Ok("Є ще інші стилі");
                }
                else
                {
                    return BadRequest("Шрифт не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }


        [HttpPost("getLineSpacing")]
        public async Task<IActionResult> GetLineSpacing(IFormFile file)
        {
            try
            {
                List<string?> lineSpacing = LineSpacing(file);

                if (lineSpacing != null)
                {
                    return Ok(lineSpacing);
                }
                else
                {
                    return BadRequest("Інтервальний відступ не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingLineSpacing")]
        public async Task<IActionResult> CheckingLineSpacing(IFormFile file, [FromForm]string lineSpacing)
        {
            try
            {
                List<string?> spacing = Families(file);

                if (spacing != null)
                {
                    int tmp = spacing.FindAll(f => f == lineSpacing).Count;
                    if (tmp == spacing.Count)
                        return Ok("Є тільки цей інтервальний відступ");
                    else
                        return Ok("Є ще інші інтервальні відступи");
                }
                else
                {
                    return BadRequest("Інтервальний відступ не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }
        
        
        [HttpPost("getMargins")]
        public async Task<IActionResult> GetMargins(IFormFile file)
        {
            try
            {
                List<List<float>> margins = Margins(file);

                if (margins != null)
                {
                    return Ok(margins);
                }
                else
                {
                    return BadRequest("Відступи не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingMargins")]
        public async Task<IActionResult> CheckingMargins(IFormFile file, [FromForm]List<float> margin)
        {
            try
            {
                List<List<float>> margins = Margins(file);

                if (margins != null)
                {
                    int tmp = margins.FindAll(m =>
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (!(m[i] <= margin[i] && margin[i] <= m[i] + 0.1))
                                return false;
                        }
                        return true;
                    }).Count;
                    if (tmp == margins.Count)
                        return Ok("Є тільки ці відступи");
                    else
                        return Ok("Є ще інші відступи");
                }
                else
                {
                    return BadRequest("Відступи не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }
        
        [HttpPost("getPagesSize")]
        public async Task<IActionResult> GetPagesSize(IFormFile file)
        {
            try
            {
                List<List<float>> margins = PagesSize(file);

                if (margins != null)
                {
                    return Ok(margins);
                }
                else
                {
                    return BadRequest("Відступи не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingPagesSize")]
        public async Task<IActionResult> CheckingPagesSize(IFormFile file, [FromForm]List<float> pageSized)
        {
            try
            {
                List<List<float>> pagesSize = PagesSize(file);

                if (pagesSize != null)
                {
                    int tmp = pagesSize.FindAll(p =>
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (!(p[i] <= pageSized[i] && pageSized[i] <= p[i] + 0.1))
                                return false;
                        }
                        return true;
                    }).Count;
                    if (tmp == pagesSize.Count)
                        return Ok("Є тільки ці відступи");
                    else
                        return Ok("Є ще інші відступи");
                }
                else
                {
                    return BadRequest("Відступи не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }
        
        

        private List<string> Families(IFormFile file)
        {
            List<string?> fontFamilies = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    foreach (var paragraph in document.Paragraphs)
                    {
                        if (paragraph.MagicText.Count != 0)
                            if (paragraph.MagicText[0].formatting.FontFamily != null)
                            {
                                string str = paragraph.MagicText[0].formatting.FontFamily.ToString();
                                if (!fontFamilies.Contains(str))
                                    fontFamilies.Add(str);
                            }
                    }
                }
            }
            return fontFamilies;
        }
        private List<string> Sizes(IFormFile file)
        {
            List<string?> sizes = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    foreach (var paragraph in document.Paragraphs)
                    {
                        if (paragraph.MagicText.Count != 0)
                            if (paragraph.MagicText[0].formatting.Size != null)
                            {
                                string str = paragraph.MagicText[0].formatting.Size.ToString();
                                if (!sizes.Contains(str))
                                    sizes.Add(str);
                            }
                    }
                }
            }
            return sizes;
        }  
        private List<string> LineSpacing (IFormFile file)
        {
            List<string?> spacing = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    foreach (var paragraph in document.Paragraphs)
                    {
                        if (paragraph.LineSpacing != null)
                        {
                            string str = (paragraph.LineSpacing / 12).ToString();
                            if (!spacing.Contains(str))
                                spacing.Add(str);
                        }
                    }
                }
            }
            return spacing;
        }
        private List<List<float>> Margins (IFormFile file)
        {
            List<List<float>> margins = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    List<float> str = [((float)(document.MarginTop/72*2.54)), 
                        ((float)(document.MarginLeft/72*2.54)),
                        ((float)(document.MarginRight/72*2.54)),
                        ((float)(document.MarginBottom/72*2.54))];
                    if (!margins.Contains(str))
                        margins.Add(str);
                }
            }
            return margins;
        } 
        private List<List<float>> PagesSize (IFormFile file)
        {
            List<List<float>> pagesSize = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    List<float> str = [((float)(document.PageWidth/72*2.54)),
                        ((float)(document.PageHeight/72*2.54))];
                    if (!pagesSize.Contains(str))
                        pagesSize.Add(str);
                }
            }
            return pagesSize;
        }
        
    }
}
