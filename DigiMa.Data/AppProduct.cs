using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DigiMa.Data
{
    public class AppProduct : AppBase
    {
        private string _sDID;
        private string _sAppConfigDID;
        private string _sProductName;
        private string _sProductLogo;
        private string _sProductContentImage;
        private string _sProductShortDesc;
        private string _sProductDesc;
        private string _sProductHTML;
        private string _sProductStatus;
        private string _sProductCategory;
        private string _sProductHeaderImage;
        private string _sProductFooterURL;
        private string _SCustomeTabName;
        private string _Email;
        private string _ShareWidgetAdded;
        private string _LikeGatewayAdded;
        private string _CanvasHeight;
        private string _AppCaption;
        private string _sCouponImgPath;
        private string _sHeaderBannerImg;
        private string _sHeaderBannerURL;
        

        
        public string AppCaption
        {
            get { return _AppCaption; }
            set { _AppCaption = value; }
        }

        public string CanvasHeight
        {
            get { return _CanvasHeight; }
            set { _CanvasHeight = value; }
        }
        private string _CanvasWidth;

        public string CanvasWidth
        {
            get { return _CanvasWidth; }
            set { _CanvasWidth = value; }
        }

        public string LikeGatewayAdded
        {
            get { return _LikeGatewayAdded; }
            set { _LikeGatewayAdded = value; }
        }

        public string ShareWidgetAdded
        {
            get { return _ShareWidgetAdded; }
            set { _ShareWidgetAdded = value; }
        }
        private string _ReccWidgetAdded;

        public string ReccWidgetAdded
        {
            get { return _ReccWidgetAdded; }
            set { _ReccWidgetAdded = value; }
        }
        private string _LikeWidgetAdded;

        public string LikeWidgetAdded
        {
            get { return _LikeWidgetAdded; }
            set { _LikeWidgetAdded = value; }
        }
        private string _CommentsWidgetAdded;

        public string CommentsWidgetAdded
        {
            get { return _CommentsWidgetAdded; }
            set { _CommentsWidgetAdded = value; }
        }
        private string _InquiryWidgetAdded;

        public string InquiryWidgetAdded
        {
            get { return _InquiryWidgetAdded; }
            set { _InquiryWidgetAdded = value; }
        }

        private string _TwitterWidgetAdded;

        public string TwitterWidgetAdded
        {
            get { return _TwitterWidgetAdded; }
            set { _TwitterWidgetAdded = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string SCustomeTabName
        {
            get { return _SCustomeTabName; }
            set { _SCustomeTabName = value; }
        }

        public string SProductFooterURL
        {
            get { return _sProductFooterURL; }
            set { _sProductFooterURL = value; }
        }

        public string SProductHeaderImage
        {
            get { return _sProductHeaderImage; }
            set { _sProductHeaderImage = value; }
        }


        public string SProductContentImage
        {
            get { return _sProductContentImage; }
            set { _sProductContentImage = value; }
        }
        private string _sProductFooterImage;

        public string SProductFooterImage
        {
            get { return _sProductFooterImage; }
            set { _sProductFooterImage = value; }
        }
        public string SCouponImgPath
        {
            get { return _sCouponImgPath; }
            set { _sCouponImgPath = value; }
        }

        public string DID
        {
            get { return _sDID; }
            set { _sDID = value; }
        }


        public string AppConfigDID
        {
            get { return _sAppConfigDID; }
            set { _sAppConfigDID = value; }
        }


        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }


        public string ProductLogo
        {
            get { return _sProductLogo; }
            set { _sProductLogo = value; }
        }


        public string ProductDesc
        {
            get { return _sProductDesc; }
            set { _sProductDesc = value; }
        }


        public string ProductShortDesc
        {
            get { return _sProductShortDesc; }
            set { _sProductShortDesc = value; }
        }


        public string ProductHTML
        {
            get { return _sProductHTML; }
            set { _sProductHTML = value; }
        }


        public string ProductStatus
        {
            get { return _sProductStatus; }
            set { _sProductStatus = value; }
        }


        public string ProductCategory
        {
            get { return _sProductCategory; }
            set { _sProductCategory = value; }
        }

        public string GetNewDIDWithPrefix()
        {
            return GetNewDID("AP");
        }

        public string SHeaderBannerImg
        {
            get { return _sHeaderBannerImg; }
            set { _sHeaderBannerImg = value; }
        }

        public string SHeaderBannerURL
        {
            get { return _sHeaderBannerURL; }
            set { _sHeaderBannerURL = value; }
        }
    }
}
