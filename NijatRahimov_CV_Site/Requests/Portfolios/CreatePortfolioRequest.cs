﻿using NijatRahimov_CV_Site.Attributes;

namespace NijatRahimov_CV_Site.Requests.Portfolios;

public record CreatePortfolioRequest(
    string Name, 
    string Link,
    string Title, 
    [AllowedExtensions([".jpg",".png",".jpeg",".bmp",".tif",".tiff",".svg",".webp",".ico"])]
    IFormFile? Image);