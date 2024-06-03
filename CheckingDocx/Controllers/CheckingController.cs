using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.RegularExpressions;
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
        public async Task<IActionResult> GetSize(IFormFile file, [FromForm] string styleName = "Normal")
        {
            try
            {
                List<string?> sizes = Sizes(file, styleName);

                if (sizes != null)
                {
                    return Ok(sizes);
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingSize")]
        public async Task<IActionResult> CheckingSize(IFormFile file, [FromForm] string value, [FromForm] string styleName = "Normal")
        {
            try
            {
                List<string?> sizes = Sizes(file, styleName);

                if (sizes != null)
                {
                    int tmp = sizes.FindAll(f => f == value).Count;
                    if (tmp == sizes.Count)
                        return Ok("Тільки цей");
                    else
                        return Ok("Є інші");
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
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
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingFontFamily")]
        public async Task<IActionResult> CheckingFontFamily(IFormFile file, [FromForm]string value)
        {
            try
            {
                List<string?> fontFamilies = Families(file);

                if (fontFamilies != null)
                {
                    int tmp = fontFamilies.FindAll(f => f == value).Count;
                    if (tmp == fontFamilies.Count)
                        return Ok("Тільки цей");
                    else
                        return Ok("Є інші");
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
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
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingLineSpacing")]
        public async Task<IActionResult> CheckingLineSpacing(IFormFile file, [FromForm]string value)
        {
            try
            {
                List<string?> spacing = LineSpacing(file);

                if (spacing != null)
                {
                    int tmp = spacing.FindAll(f => f == value).Count;
                    if (tmp == spacing.Count)
                        return Ok("Тільки цей");
                    else
                        return Ok("Є інші");
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
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
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingMargins")]
        public async Task<IActionResult> CheckingMargins(IFormFile file, [FromForm]List<float> value)
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
                            if (!(m[i] <= value[i] && value[i] <= m[i] + 0.1))
                                return false;
                        }
                        return true;
                    }).Count;
                    if (tmp == margins.Count)
                        return Ok("Тільки цей");
                    else
                        return Ok("Є інші");
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
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
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingPagesSize")]
        public async Task<IActionResult> CheckingPagesSize(IFormFile file, [FromForm]List<float> value)
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
                            if (!(p[i] <= value[i] && value[i] <= p[i] + 0.1))
                                return false;
                        }
                        return true;
                    }).Count;
                    if (tmp == pagesSize.Count)
                        return Ok("Тільки цей");
                    else
                        return Ok("Є інші");
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }


        [HttpPost("getAlignment")]
        public async Task<IActionResult> GetAlignment(IFormFile file)
        {
            try
            {
                List<string?> alignments = Alignments(file);

                if (alignments != null)
                {
                    return Ok(alignments);
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }

        [HttpPost("checkingAlignment")]
        public async Task<IActionResult> CheckingAlignment(IFormFile file, [FromForm] string value)
        {
            try
            {
                List<string?> alignments = Alignments(file);

                if (alignments != null)
                {
                    int tmp = alignments.FindAll(p =>
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (!(p[i] <= value[i] && value[i] <= p[i] + 0.1))
                                return false;
                        }
                        return true;
                    }).Count;
                    if (tmp == alignments.Count)
                        return Ok("Тільки цей");
                    else
                        return Ok("Є інші");
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"помилка обробки файлу: {ex.Message}");
            }
        }



        [HttpPost("Picture")]
        public async Task<IActionResult> Picture(IFormFile file)
        {
            try
            {
                List<string?> pictures = Pictures(file);

                if (pictures != null)
                {
                    return Ok(pictures);
                }
                else
                {
                    return BadRequest("Не вдалося знайти.");
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
        private List<string> Sizes(IFormFile file, string styleName)
        {
            List<string?> sizes = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    string pattern = styleName;
                    if(styleName == "Heading")
                           pattern = styleName + @"[2-9]";
                    foreach (var paragraph in document.Paragraphs)
                    {
                        if (paragraph.MagicText.Count != 0 && Regex.IsMatch(paragraph.StyleName, pattern))
                            if (paragraph.MagicText[0].formatting.Size != null)
                            {
                                string str = paragraph.MagicText[0].formatting.Size.ToString();
                                if (!sizes.Contains(str))
                                    sizes.Add(str);
                                if(paragraph.MagicText[0].formatting.Size != 14)
                                {
                                    string str1 = "DFBh";
                                }
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
                            string str = (paragraph.LineSpacing / 12).ToString().Replace(',', '.');
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
        private List<string> Alignments(IFormFile file)
        {
            List<string?> alignments = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    foreach (var paragraph in document.Paragraphs)
                    {
                        if (paragraph.Alignment != null)
                        {
                            string str = paragraph.Alignment.ToString();
                            if (!alignments.Contains(str))
                                alignments.Add(str);
                        }
                    }
                }
            }
            return alignments;
        }
        private List<string> Pictures(IFormFile file)
        {
            List<string?> pictures = new();
            using (var stream = file.OpenReadStream())
            {
                using (DocX document = DocX.Load(stream))
                {
                    foreach (var paragraph in document.Paragraphs)
                    {
                        if (paragraph.MagicText.Count == 0 && paragraph.Pictures.Count != 0)
                        {
                            string pattern = @"^Рис\. \d+(\.\d+)*\. .+$";
                            string str = paragraph.NextParagraph.Text.ToString();
                            if (!Regex.IsMatch(str, pattern))
                                pictures.Add("Рисунок " + paragraph.Pictures[0].Name + " неправильно підписаний");
                        }
                    }
                    if (pictures.Count == 0)
                        pictures.Add("Підписані правильно");
                }
            }
            return pictures;
        }

    }
}
