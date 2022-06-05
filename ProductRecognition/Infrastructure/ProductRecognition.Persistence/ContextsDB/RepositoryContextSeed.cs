using System;
using MongoDB.Driver;
using System.Collections.Generic;
using ProductRecognition.Persistence.Configuration;

namespace ProductRecognition.Persistence.ContextsDB
{
    public class RepositoryContextSeed
    {
        public static void SeedData(IMongoCollection<AccountConfiguration> accountCollection, IMongoCollection<ImageConfiguration> imageCollection, IMongoCollection<ProductInImageConfiguration> productinimageCollection, IMongoCollection<ProductConfiguration> productCollection, IMongoCollection<ProductFrameConfiguration> productframeCollection)
        {
            bool existAccount = accountCollection.Find(p => true).Any();
            bool existImage = imageCollection.Find(p => true).Any();
            bool existProductInImage = productinimageCollection.Find(p => true).Any();
            bool existProduct = productCollection.Find(p => true).Any();
            bool existProductFrame = productframeCollection.Find(p => true).Any();

            if (!existAccount && !existImage && !existProduct && !existProductInImage && !existProductFrame)
            {
                accountCollection.InsertManyAsync(GetPreconfiguredAccounts());
                imageCollection.InsertManyAsync(GetPreconfiguredImages());
                productinimageCollection.InsertManyAsync(GetPreconfiguredProductsInImages());
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
                productframeCollection.InsertManyAsync(GetPreconfiguredProductsFrames());
            }
        }

        private static IEnumerable<AccountConfiguration> GetPreconfiguredAccounts()
        {
            return new List<AccountConfiguration>()
            {
                new AccountConfiguration()
                {
                    Account_ID = new Guid("C370B962-0EB5-404C-B3D6-8373B79FEB92"),
                    Username = "Владимир"
                },
                new AccountConfiguration()
                {
                    Account_ID = new Guid("817D8895-4A86-4D83-9CAB-44C6ADDA1E99"),
                    Username = "Евгений"
                },
                new AccountConfiguration()
                {
                    Account_ID = new Guid("DF52BCA9-3E33-489E-8CE5-CD665C163589"),
                    Username = "Екатерина"
                }
            };
        }

        private static IEnumerable<ImageConfiguration> GetPreconfiguredImages()
        {
            return new List<ImageConfiguration>()
            {
                new ImageConfiguration()
                {
                    Image_ID = new Guid("a2474e4e-aec2-497c-b0b9-a55aebc67ed0"),
                    Image_Base64 = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD//gA7Q1JFQVRPUjogZ2QtanBlZyB2MS4wICh1c2luZyBJSkcgSlBFRyB2NjIpLCBxdWFsaXR5ID0gODUK/9sAQwAFAwQEBAMFBAQEBQUFBgcMCAcHBwcPCwsJDBEPEhIRDxERExYcFxMUGhURERghGBodHR8" +
                    "fHxMXIiQiHiQcHh8e/9sAQwEFBQUHBgcOCAgOHhQRFB4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4eHh4e/8AAEQgAyADIAwEiAAIRAQMRAf/EAB8AAAEFAQEBAQEBAAAAAAAAAAABAgMEBQYHCAkKC//EALUQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFB" +
                    "BhNRYQcicRQygZGhCCNCscEVUtHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6Onq8fLz9PX29/j5+v/EAB8BAAMBAQEBAQEBA" +
                    "QEAAAAAAAABAgMEBQYHCAkKC//EALURAAIBAgQEAwQHBQQEAAECdwABAgMRBAUhMQYSQVEHYXETIjKBCBRCkaGxwQkjM1LwFWJy0QoWJDThJfEXGBkaJicoKSo1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoKDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usL" +
                    "DxMXGx8jJytLT1NXW19jZ2uLj5OXm5+jp6vLz9PX29/j5+v/aAAwDAQACEQMRAD8A8kCWRNxeyNEsNuvmzRkZcHoAnqD0HXnjOevN6T5smof2rdQSC4vVaWRAAdqqVCADI52nH41Pf3Gm+KdSiWKz+zWFllPKkYGSSY/eLEc7RxjHWtBEX7VCI1+RYXHTjGVwP0NeapNb7nr2UttiBQwt0aJpolA+W" +
                    "MA7VznHH3e+cnNFus01xI73U+SwPUBuPcAH0q+ihUVewFIyjGV654/Co5zTkKq2FvI5EyJMQOGlbfn67u9Q2tpnU5Zo4rcW6IYU2jbgg5bPbqMf8BrUiaBJBLKypGnzSlyACo68+uKrwYijRVhaJMfKFGdo/nTTe5LirlS7LNq1ndXGVit5DC4VuMSZUkn03bD7AVJFFLHfy3EEzwRoxgh8vgbQ3zZB" +
                    "4PICkEY+UVHfYOlXZkyVmDqiAE7jjbgDr1A/OrmmJPcaRa3P2d1SSPJAGQrDhh7fMDwea0c3ymaiuYsCZQQphjBOSSRwR/T8KdLlpDgsGYjdn5vxz19KiQA5BcLjg5609ieFVlkHUcDI9cdxWSNmLIqrIsWQ7kgAkYA9z6Y/WozmUyxBH8oN87LnkenIp90hmj2BI1ZEycdcdgPfj/PanM968CI7GPM" +
                    "u2KNT904HzE98LkjtmtbdTO/QieSSS2M8CBt3yCRxhdpbauB/F1znpzVi3giWAQxx4Urgjr+v+NLdOpeGHBl3sPvHlSOR+JIwP/1U/a4ZUyEBHbBI/HpSbBIegDKrFiezkcnI4J/P+dUrwQXlxDZMVeLIkmx8wKj7qn1JYf8Ajp9atLFCpeSc5RfnbcchQBgnB+nak0m3JtXmnYtLcSlmDcFV6KPbAAG" +
                    "PXNWtroT10ZowxkRlSyqobapkIG0jHTHJFV9FW2iv7u3Fs1yP3lxE5b+LGHIAxgZBye4YetF6zvM5iXyYy332PQE9vQ471Wvre5jgjktAVkgYOkYPEmwg7G/2TgA0c1nYLXVzQmlE8DmVw0hYYAXsP5A5/SnS3D3flQB8RrneQBkcYwCfp36YHGabDeDUIFmg2pbyoHUrbICFbOBnAOccZz/SnRRCVES3" +
                    "jxIxPybjgY7/AHefXH6nrU3kmVo0Y3idJD4Z1Czjk2oi+cu4dChB4Pb7o/Wr9/Hbajp1/bzwkxX0STRSRgjAK434P+8nH8s1bu4La4iljl3GKUsrnYCrZHIxWP4VvDLoNhFMArQxPby4UFVdDsHB6cBST757VSbsZuK5h9pcT3GmWssplBkjDOrH/loPlc4/3g1SrI6oUViFJBIHc1DpHkx3Wo6XcBo28" +
                    "9Z7aUkbR5gIKMOwLIcHoCeeDkTyRtHIyOhVlOCCMEGoe5pHYi1OR7m2fzNm4LndjHToDjsMflRU5gXYd43jHzRqpzg+vpx/PvRVwkkROLb0MTw21umm2vljastrGwI4DNlg3XvkEfUGtIRyNceeEyu0JvXGM5Pyn3xzWXFNaaVfrKukwz2zoA1uWKrkEAMrJgg888dOuTgi/eanJcyu4kNqAFaK2hBjTj" +
                    "jPXJ9Mtzx71Mo31Q4y0SfQthSjlXzG4wCDnj/Cqj3CpIiAFtzZCjqazZbnL7fMbOSTxjFSyRQo6yKylZACozyp7g9cdKlU2U5l24cPHDDtV8ypuV1PAB3HkfSntKsoHlSIiDO6ZhkY/wBkEjJH5c+vSrNCTDYXAe4VDMdrIzKAoRsfmcjt0PHOamMyi3lmJVSEK85PqAM/5701GzSFe92Vptlu9usLefI" +
                    "0u6QJIMM204Bx74POcBc9qsWcb2RMkspyzmTzYmMbRMeuMY+T9Ryecmo7BHa4N3PvJfPl7h8wU4OT7nB47YA7VoMFIyRn8KmU7OyHGF1dk13JeciZ5XdeqSksSfx5oEZkjDrGflJDDbkr+NVrVpIoTCkg2oQEVzxt9vQDODj8etWQ8mDEOhxuGMAdcc0PQpCMGi2yPG6nOAMcn8PSqzyCW9a5ZSxCmNMD" +
                    "l+mQvsMD0wc+ozK7puEcS+ZLg/7ij39fp346VGEZGV8s5Aw/HUew6DHoKeysTuxViKF/MAZpDmRccDjGB7cU623PtV2DYG4FmJO0k4H5UtyTJCql1y7BQGHb1BHtnv6Ul4JLKPzJghGzeMZBIx265+gHWnbsDZUvy9zeRWq5CIweQ+uGyB/M/gKuwyhC8aqdwfKtnOQRkj8yTVPT1JkeVlw7tvk5zg9AMj" +
                    "qAD+QFW1RnuZcDA2L/ADbmiV9hRXUts8t0yREK7AbQoABIOf8A69WL8ySXDN9nEOc5SME989e9UZIY3UKyKQo4wBx9Kbc21u7A/Z42Xao24wPr6Z560lZrVjd09EJo1tcBrm1jVz5cnmAZwDG4yPyww+ij3rR2rFIrG4AZDkCIbto+uQPyJrIwtrrEbQgwx3cZhlAJ2DGXQ49trD/gVaqvbwspCiZ+u48" +
                    "KvPYHr+Pr0py1e4oaKxDqAFw0drbGZJLlzgqOVQH5368YHfJ5IqjodvBp2oavpcEqYjmWa3TGBsYLlhnjll/zmpraR7q5mnPm7SCkRHKlAeScdMnPPQgD05ZZ2w/4SO6mEjrL9kjV0KH7u9huBBzxkdvT1qlZaEu7sy3Dbpa6i0molUtZLR45EKqXONrKRkj7o3n6H0q/BCLTct/KgEUOHLSLvRRjDFzk" +
                    "AYwAck8/Ss2dBdTrdPbzuFuA8pmAKBQSHHqBt3DBHf3q7eSvKIrQxq9hFD5MKhCiSFciIY69Mc5JJP8AdOKTVwUrMqSXjtZXU+hyW0jSIVQRzgOzemN2R0Jy3PXGKKiSLTrfVIraM79sZlfzcAkkhPlboDyx3eqd6Kr3VuiXGUupyAvA19G8Z3RDdGMkjdkcntjpj86ti9JVUZeF4xuPzAdCefeobiGae" +
                    "FpY7iFUjG8Ip2Fj3AXjJxnpVa4MsY2sE6g843H098U0Fya4l+ZEVeSQvseDz+hq3uit3W4aTa68gKc7jzgAH6decVVeUK8YUIvGcgcn/PNNjjGwyyEPK3yqzA8ZxmhILmlKGLxXcpKEyL5anJCKTyc+uCR9PxNPeM3d8BtBUtlFIx8v598gY9Ce5qnFcTPcxqUVwjk4buMYOfz4/GtywSIFjHiMMNpDf" +
                    "MSPTPbuOOKLpLUErskjjWVdzMEYDPPX8OxpxwTkcChiCflUKvZR2qtc3KxBgCNw55rk30R07bksynaGBAIYY5Hc+9K7DpIpQknlGIB+vcfr9aq+e52DOODkmrEE7ux4+UgAH1FUm0J2Y2GMRyMRjae+ep9fxzU4PcYIoJJxkk4GBSUr6jsKB8wb+6QRz3pWWW9RLeSQqN3GeV67sZ64J7CkFFWqjRDpp" +
                    "lmN4ohJC8atIeFlB4P4cVBLHIl784ZcxjYSMZGW/wD10rOXZmk+ct1JpuAckt1bgDtgAU+ZPVhytaIl5zyRj2pxzvCKASf4i2AKiBwMEn60oYdDnB4+lJWuNle6MpgkuFco0LiRWi+UgqQQQeoOfQiprudry4+zFlhuJQTvjXahGOcgfdY9B2JYYAHFMvnWOyZ3ZolLLgogcthhwA3BJ6fjRYWwu9Pe" +
                    "9dQjNNtYFgETugyTyOvHUnPrzrHVamUtGXLS2EcOS6sANscUTq+0djxnA5z/AIdalvJILPXLaEWrLeXCPC8SIQVwAVydrc8McDA5Jz90DNhZWibddQW4ICiXD7sjAKk4zjj0/E1QfUY/t1hYrau5nuDGJWkIO08A4HbcRkdzgU1C4pTNrU7lJI1iaKZoF3GaWUgkHbuUYIwBn35z34qCylkk06LRpJ" +
                    "TthhE4QcgoTjZjHJSRmAOQcFfTNU4oJbqRbaIEkvhefl7buM4/ya1wYEs20+6uJo1QeY1zG20u64GVIzg9MZABPJyWAFuNtCOa7uVTC6X0l9cxgGQLEm0coF5xjoR85GMD680VqaZcStp1+tzZxq9kwW4XLFPmXhlwQSvynOM4OR0oqdVoWmjhYpme2ES2qIoO7PO7pVd13s6sTKqxkbScYz6GrcUf" +
                    "lht+FG7nipI0jWUuEIUDDN+f4dxVKJLZmyMGFrOuTviZmz2Pb9CanijIiDAnHZevpTDEzSytvchmBAY9MZOMdhzU9u7Iw3Z/P8qLWFcW2ilDhmYoRwB2xW9bRlIgpO7Hesy0jaSbLSED6Voyy7FOCeBxXNVbbsdFNWGXc/l8KwB7g1nlo5EMn3iV5FSyPuYMw3KTVWO3e4uXjUAQqcf7w9PoKdNLqK" +
                    "b7FyFTMV8tcqG+8TwPWtBV2ikgVVjAUbQKeazlK+haVhBR3paKkoKKWkp3AKM0VFPIIo2Jx06etNEsmmZFhVvlVjzy+3v7/wBKoPqkbOscEDKxB3NI3A9McdfqKoXFzM8+WIABIHHSkjMQDBkbuAQ2OfXHSt4w7mMpvoX7Q313cR+W8MSSyBZGZk3YIzu+bqOvSrV2xttQjlj1GWWWDCPvJBzjlSD" +
                    "kEHHvyOhrIt9oIKj5d5G8sNwzxnA54yenX+fQQRLqMCwzgS4YlGZxvVQM5AGSR2B4HI+lbqKjuYuTZBGmZZXjktSsaBtssSqcAHJI43cc5BJ6+4qCfwxd3Wnm6vGOlLLtVJJmAZEP3AB1Y8liAM847Vo6jPqFrqRs7G9aAwXO1ktY5Vd1VgB5kmMsMHOAQAAevWsy9lW51OSeZQzSTb2lG4kexDZzx" +
                    "159fxtXe2iIdupdV4bux8+wt5ZY5VfzJFjILHcVYFf4VDZwvzH35pl15kcio8iW6xs4dQB8ig/Mc98f0FReF7q+gtb9bK4D28Wou0dqSyOrHacpIOhJz1yD6c1btRHd6iY5rWW5W2iDzBwFlLk5UOfu7QQSWBIORz2pr3VqgT5im41DUDIi3c0caKs1u4JEimNsA5z1xIcr6DnkcFdDbW6QR3ZeFFZoA" +
                    "cL8xX54wAAenU56Z/AUVnyttlppLc5O4UTT73HAbDEdevX3/wDr1BJ5bh8EgDj1/StHzIkj3FZAJDnnB2nJ4HPT6jPFUEt4LUGSKFyVBG0v1Bzjsc+4z+NXoxO63Kg8sAPHHuOMHB5wD2/z61GwIPOMZ4HSlmlMV1F5K4gnLcDqp9PpVm4SMGN9gyYzld/Q54OPpSloCJopAEBwc9sd6cXZ4247ZB/G" +
                    "o4YpXxsjY5HfpUg8xECqOh646YrllqzojoiFi5hEUZIZjncOo9at2UAVV8vaBjjtVKFpCfMVEc5ySTya0IZ98eehPtVcvNohKVtWK8hMnl8nHWpEuBwAee+ap+cUuj8uVbrx0FMlnSOfCMNvTJOcU1STD2tmaqPu5/OnjB5FVUKuQUUsp5OOn/16uAAD0rGtBQNKc+YTtSVn6hdktsjO0A9c9TWPLdX" +
                    "aSFYpCFBzg9KySuU3Y6jis7V3jAVC3ze1ZljdXWxo2dsE5yetOc53eY7jd6c5+taQWpMpaEcgdmCsrhlOMAVZVcksysSgyRnAH14/TrTVYrGACsmchQx5xz2H170sEbsEL5yg6Dp+FdcUc7ZqC6sRGBHpp8zJw5bKueOq46HJOPapka9aR7U3S2iCT99FDOSXKgdcbieBj0H0qtDJMpRtqIoHyP5SFj" +
                    "zg4Yjjpin/AOvBmndEVcrgDlic/e7/AI9K1UEZObL0WJbYyxRySwc8RNvaP15BI6Hj6CmGy8uXb5LIQflyKrJCPJz5ZR+m4n7v4jn9Kk1KXUzYLaKZi07eT5zxnECk4JHUM3ZRndk9+26XKjJu7IvCk4/sjUrtZjFG1677yu1MKTt245YnPHvgYODV2zimnTzo/MS7ZzIJd2943PJHPBUgKDkEcflP" +
                    "ZabHDEmnvNELexbzYLchnd8HBDEEDjPygnIDZPIGNzTYo5Yy8VmBCuHIDAyS44yd3AB54zz36URjzsTfKivayOp2XbAfu8HZIPKd92VKu2D035U5xjvgUVJqflQ2whXzY7iN1lVnlUneckcDg46HJGcntRUqNRaw28x3g/j3OFigFjF5Ul5NO0g+cOoK5z1AAzzT7NRe3MjNkMBt2jPPtVu8jeSVwG" +
                    "bEeUcYzkDOelFvpkjEXEZW2CAHcr8nB4z27Zzz1rmnNU3qbwTnsZl3Zw+ZGLdc5JKgjOCOaswCCWWIlB5xHUDgVX1qG3SUND5asP4weT61U0meV5S2SJGfgKM4GBgZp3927D7VjalNxDEAQEAbnBzwfbpWXqtxIlytsgZnfGBn8/05/Kuu1bQJG0KwvY9SsmlmiYzQrnzYcEBd4PHzZGME5riYEnZ" +
                    "zcko8jZRP93PJ/P8AlWEHGTfKbTUopXLWEMoMwK7Fyu0849KspPJFtl8v92SASCOF+nvUUCWUUKuQzuD8+F6+30p9kR5iRRxSGJycbxkD2z6VfNyLREpcz1LCRwSXMpKqzZ+UMOgPHSmpY2juC0QyDyAeCaszW6xkssbEoQNw4JFPhtzkyRM7Rk9DztoVWMo3vYr2coyta463tViJIdgD2Jpb1gIim" +
                    "Tk9MGkYusWMcZ4xTGAY7pI+AOK8+dTme9zrUOVbGbLAWiO0MHz0x+uaEsckMx5745rVgijeVQze2ewq4LceW0hwNo4Pb8qzdS2gKFzEisW3cgk+mMVBNCFchuTXUwpEkSs5JOMgY5PvVK7gheYSqQNxxjGTn8KulV94U6ehlRWG9eFAJOQafpkYCzrKMvExUg8HJwR09jWgpnmkMUZVAo5+UCojEkd" +
                    "wwIYSsBnjOSMDgf54rtp3loznmlHVCxwbkBL/ALrO7GfbvTxCPLWIGOTcNy7TkYPXp/Wlt5USRnds7SVxtBzj0B//AFcjvxVm/sxHbxvcxgqVwsIJb5mHC5GfUDjH9K74J30RxzaS1HWVoc7mEdyqhTIpfG0HPXj2z6e/pKGeIzau8RF220eRc4HlAqcYwSQAcHK8kj8adaQJCqRxrt8xDuK4Uux4LH" +
                    "147/41DLMgst+q+au1Nv2pVDAxg43MAcgkANwD7dcC5QaWrM4zTehev7cpsu4T5zxjMzIpy0ZA3d+egOOhKitF3SG182PKQxozBwflkIQsGB5yOOD6Gqtrd2620QtbmAwmIYZpAflxnoD155J/Kq1i+2wk8mR7u0hmaRoihQIdoOI24IycnoV5HTu5SUdExRTerNJLzZbWs65a4YjzWeMBpCRyc5OM" +
                    "8kgUVasGN7HEilirf6qZW5GMjB9D049c96K6488leD0Od8idpLU55dGuZ47rUIDOIbeIGQeUxCheDk+gwRxVvWtDvbBYku3Cq9uHhG/cWTJA546YNW/DXiKO98OXlpprGYJEYr0mPCx78tjcMD7+RnqffNM8Y3mpahLH9otzE6QKAykfMSvfPf8A+tXzUZ1atRJ6W+891xp06bcdTgtes5pELxxbwowww" +
                    "M9e38/wqPwxFC96EubkpbvOUdkUttAx2ra8qRtNuY5YZpIjuXpt28gHJqzo2l2MLSCwiadEmyd3bAxj3B/xr0Jq8GcMW1MPF91HZWJFtO08txGFGM/LwOG9gAD3/rWLocEC2WZZFEspCKzkAhR93A64xyT6mtLRrV9S114J0kMWHZiucEhGOOMngirM/hy4k0y5vbS2mZ4r1Yozs52MrnPPPZeg71x88K" +
                    "C5L6/5nU4yrPm6GPNpL+adihsnBYEHj2A/xqL7JJZTAXls6koQhTPuMjk/lXYaNB5DxLdvM6CBi5WFsKc8A/L2/H69qs6lPHbC3mNpO8c1w9tGxiIzggZPbv8AnXJPGtSta50wwqavsZNnHbS2UcxdnHAIPb1zWrBox8n5I3Ksu7GcjH1rNtp/tstzai3ljWKYIoVfvqOM5+hH513aW2oWM91pl4tvcT" +
                    "WiREsj7l2MpIwcc8YHHoa4q9SSTktjvoxg2ovc5LRdFa81NLVUKeacBmz8vuQAeOpqXxfF9lMeifYrSK4sVaJ5Ix88pDEnce/UgewFdFrVheppf9qQQRQ28BLrIjhWPOPrnIPauQ1S2vLrU4mt1GFVSxXuWXcMn1ODWMJ8z5mx1YcqskZ1tazNGzQxNIQOdozjPHPpzW5pFo+pxNaxI73LAAIq5Lc9vz" +
                    "FO0+CS2t5YEaaOeQjeQSBgE9R7HB/Cu78J6zp2gXdrqS2rTzxblLyIAJY2QgjgnBDtnd3BI47TUxD2RlGnZXsee61YXNoLRbm0ljNxHvhDQn5xuKggnGRlSPzrMu9P1AbLqSySOMnqTgMR6du1dhB4i03RblGuEie4uN7RlvmMIYn8eDnHp+PNDxzJdyLHa28Mq26kxp8rAOVJBPOMdRwQfrXVQqVXKK" +
                    "tZd2ZzjGzbZx0M0sTFQwR+cgY/KrF1dSz3FrGjpJJ0yqHIyOmPwrovDmjRxzq11bh5Ix5kjN0QgEgZweeP19qufEvxO2sQWeoz2cNs1pIokaOMYkO5vmY9dxLcnv35FetTrRlPlijhnTlGN5M5iNG4DL5ayHzMsuDJzx+H0q3veSVWZS5hk3p83JJBHPp1Jz19q1dV0aS1src3Ji81kCgJxgY6e54HI9e" +
                    "uawL+6W001pCzIiSKpJ4Abd1r0cNXhJaM48RRlF6j/Pktb+5MyMRuXa6Y2LnPYgkYAJPXvTNXhI0aGaQCcTBCoYgZXcByPp29Kla6V53dk2vv2D1IHT+f8qilWCPTUgMAmYfK5JIIw2R0OeBg/wBKHUlUnyrZNEqEYQ5n1TNaaze30TTILYs5hMUZZeDtyqnI9Pb/AOtS28LSw3TIrpHIyIAuACRk8fg" +
                    "B+nWrNpd2i6HJZ/Z4neUp5bBiojG8EnP8RI45yB1q4luqaRC8aMd7yEjpwAAM4PfmtqtZKVrGVKk3G9ynpUk1nMJY0G12z5T/AHXC8DP91scBgPrkUVCk9xdOkarK9yFZ1Tbhgo/TI496KyWK5fhujV4ZPc3tA1+z0XRBo2nabDBA6qs2zG+fb0LkDLGpJtc0K8DC4Lwu42tkZ7jt9ABXNJcOerg/UVI" +
                    "SkufMVWzXF9Rpp3i2n6nWsVO1mk16FjxLNYNp939hlSRpYGQN2Xgjke3H4CuD8C30t5c6nFb3DByqqj5xuYMeR7dPzFdg1haurL5EYDdcDGfris6TwtYeYZbVGtZM53RHHP4V0wpqMUjnm5SlcXwxqr+HNRF7YSS27w7jvj/eEE5BGOc9+K9C0TxZczxSXF6s6rPNuNzFHIgLBcAdOoGPwrl9EeTTpf" +
                    "Mv7b7ZbqDuaHAkyTnOGOD37ity+8QaLH4UtoxeRpP/AGhKHiZgJAPLjOSp7c8HvzXzmaRmp3cG/M9jBuHLZS+RuXHivyYBFaX7NAhBWEwvgEdwMYFVJfHt7KuZLyY4G0b4Xbv71x8c9nJcyfvcZiDnhe7AVFLLA9vCY7k5KuSBjivOjTit0dilfVHS3HiqOePEwilXplYWAH4dKrjXhA+61aaHd18t" +
                    "ZFz+Q5riJpG8xgL6UYfH+ea6HWbSddXvVW+Zgku3cYx83H1rq9lGMbiVSUnY2Ptmq6zKLe21G9YuPnR5ZFUD1OcCux0zwnrV6IZtR8TwR2/ymeJp3l8wg9x06Ad68quluLRhKt5lgT0j2k8+ua6zXNVivvENpYXFvbrBHaRoVYpL/BliSDkHPbqKxqN202L5ddTX1zw3Zw+I3tdEmvtS83BkdlACAn" +
                    "O1epPTr2z0pnjPwwsHh26ZlGnaoI3FhbGUOxHmYVnKjj5c/l0BrMg19NN1G8ttPvby1hik8tFt52VAN2OhJHbrjNZviK5f7HFrE+qi6SRcyxvlXX59oyf4u1Y0lKVRczsRU0Whp634P0bWba2l0u7uVu4tqJHOkcQ9xu3sSenbnJrs9E+GniG+1Pdc6riGLJH2gFwScc8HPTjJOcg+ua5TwzqEEETf" +
                    "YLCSK+yBuWdVcnPq6uMeortodd8YwRqUt794wv3VaJyfyjUD866ZSaXLfQjke63NST4SXQjUvr2m26KG3gIxyD05/WvPfiT4J8P6V4cu54vEsVwyfeRICwdwDtAcgAemM85HpUviXx74oRmgudP1O2TH3iic+2Q/8hXG6t4vkntltrgz7GPO62Y8+vGa7MJQldSjt6nLWlZOMnf5E+hWmj3ukJdS6p" +
                    "c2so25jZE6gDOAX9R6Vz3xJuodSlitVuluWlaNXkS22MqxqAMAE9qjbUbFWLm42Ln5t0bL/MCpDdaWxUm9sVzyN0ig/ma9mlhIwqc5wVMS5U+QdY21tbRKFdmBOcsTuGexyTxWLqtxKmrPbO4QPsdVB4JwRjsOwrUlvNH83aNQtmbIG0TLjPua5XxD4i02PxPZpaol5tjCs0bsNrBieOxNd9OMYvmR" +
                    "w1ZtrlPTrSIbFgdUfb2PK5wcD/H+dN02XWIJVu7eWRGLJIWU8Y4IHGOmAe3atC208yOAiMcxZJHO3KZ/Djj1+tddAti8IkdEYnsTj5vx711OipvU5lWcFocEkeqfLLChjIfecLljznIJ4+lFehKdPMbsZYVXo2XxjnH4UUPCw7B9ZkeIjxf4SjOH1iIn/ZVmz+Qp0fjLwyZkMUl5cIxxiO1kP4/drn" +
                    "bVIxEJI4415wAq81ZupDABIJMk/wCc1531intc9H2VQ6KPxdpjyeXb6Lq7YXO5rcRqfxZhSt4on3lYNDeNSBl5Z0yOnAxnn8647UdQmTTXmWUqx4U1g6Dc3N5DJPe3EheKXKjPHAGK15rrQybs7Nnd6JqficzyJqEtpJAZt0QuE3SheQM7cD0rpvEHh7R7TwToV5cW8V7fXl3dma5nUPIQnlBRk8hRy" +
                    "QOgyfWvNYNbmmuHlJ4GDW/deJJ76ws7OaXMNsZGjX0L7d38hXh46dao0tkelhlTirot2qWr+ck0McgdPLCsoIA6082OlxxyGOxtlITj92OtZEd4EAcNzuzTrjUBlxu6iuDllfRnapxFuXQONoAO7JwK231gbHJOSec+9cNNet5+d3enPfMY+vJraVFySTJjXUW7HXRaot3PGkh4AOas+MNXtovF8htQ" +
                    "yoyhjkYPKjP65rgo71o2DA1LqN41xem4kl81tgG78On4dKl4bUUsS3E9F03SDeeEdV8TCbm1u4UKnv5m/n8wKnk0G/1PSDFAhkjZPL477V3Z/SuT0fxL9k8D6ropkO68u7WRRjjbGJd3P1Za7P4XeM49PufIvfmg8iSMfLnBYDn8ga4MVCrTXNDoaUqkZOzOevtcuba5tIIWZZpsHI9cgCvR9C+IGoaT" +
                    "ep57B7dwyBWHIZXx/IVxfih9JZrCWAJ5kVvE+QO5UH+dcr4j11p7yJwNoXOcepYk1tSpRxUVZWCVV0r3dz6Nm+ImlX0RhvNNSRWjY5A9FJryr4g63ox0dpbC1aOTzQFyO3pWP4IvJdSuTZRfPMyNsHr8p/pT/i5ZnT9N0yMIu+9cPgdVwQx/nWmFouliIwbCtPmoOSMm3HmWyzSsUc87T6YzWfNqqxy" +
                    "xpnKu2ARV/XWNvbhRycFc1x2qSGK1iIB8wTpt/Pmvdw9ec3d7HlV6UYKy3OlL2cz5kt4ic9So61y/iWJItftLWwihhjdFaRkhUNksR97Ga0NKm86MgnkSEH9Kraovmaq8g4CFVB/Af1rupz5pcpxVYWjzHokX9jzTIXsLfLbVdggyeMZzW1Jp+myWnkxzTQqowBHOy4/I1wljOUtZW3EHr+NSW986ODJ" +
                    "LIAfQ13SrqGjRyQoOezOoPhuKeNETWb4GN9wH2huSOOfXiiuaa8uHUhZC4Y529ce5Hp+FFQsVE0eFl0OYsLsO0UZmWIF/vt0X3NRX16xRvnHHSsSGYr36VLNIGhOTXkQiqbsehKbkizcXPm2aQMeCRUEDiGyYKeXbNZd3eFcKp5Wmw3RaNAx6CupuyOVas07S4VAVJ6ihdRbzgA3GayrubagZTz0pYz" +
                    "hFk7msXTUtTVTa0OmjvTsUk1FNqGZCN1c/JeNjAPSmRzMzZJNc/wBVV7m/1h7G2Z9xzmlEpPeqMLYHJ7VKJBUuCRSmWy/AprS8YzVfzKgmkIOaOQHI1IJs8E1eF4VjAU45rnEudpHNSrdgjGaiVG441LG9PqMu/G7jaBVa6uhKmD1FZhuQx65qPz/mPNVCkk0wlUbOv+HWvf2L4s0++kYiKOZd/wDu5G" +
                    "f0zV3x34rfXdbtpGH7q3UhB+B/xriYJtvzDrmk8/MxYntitfYQlV9pbWxPtpKnydLnRzatJPGiOc4GarXaiYJ/vhvyrNhk3BTmriy5VU7130aUUtDjq1JPcfFILeWRRwN+6knnDQRsfvOQx/Gq8redLIRwOn6VXvJNkyjPyqwpqm4Sv3YnUUo27HUxv/oe4nrSySxmKI5csF+b0rPmuAttEoPXmmRTZh" +
                    "Yk9Dit6kFJmNOTikbE90PJRrRY1kABIYqSMZ6bup4zkCisyA+ZcgdgKKydBvY2VaxwyTtsyTzmpPtLFMVUzxzQWwtc7imUnYbM25jzSw5wPWoyck0+Jsc1bITHTkkbaBKdgXPSmscmmKMc0kU9yZulPhIDE1Cc05c5pMqJd83OFFSLIKohiKejkVDgrFqTuXQ9MlbIqAOaC9Z8tirjHJ3U0M1SYUoWLA" +
                    "MCMD1HPNIuMVatYQ5HIFHmHNIx44qFsg0JIGy6s4C0sT5TJ6k1RBJ4FSqWUAEYqkrEt3NCKXHercU+XBz0FZAkqSOXBzmt4OxhNXNaKTBI9qr6md3mYPfioYZvmGT1NJdPuI/2mrVu6M9jSaRnQDPCgVKj/wCjnnq1VInGCPapNwEW0GrS1FfQ1NPk2y7ieooqgkxXaAaK1UrENXOQzxSE8UzNBNeedF" +
                    "xc0qmmZoBoEmS5oBpgJpvNFi7kwYU4NUBZtoGeBSqTmlYamT7qUNz0qIGhZCjZKBx6GlYrmsWAwwxBHYYpAx71WT75J4p7MB1DH6UuXUalpcslsjmk3cVDGzeWFJO0dKcDS5SlK6uSbqYWpM0xjQkDY7dg5HFLvJPJqImlzVWM2yffkUpeq2+gsataENlyOTkYNOkkJI571VVvenb/AJqu5DNGOU461Ks" +
                    "3HWs5JMDrU1sJJ50hiXdI7BVGcZJqlKwrF9ZfmHPSioby3u7C6Nte28tvMoBKSKVOD0P0PrRVKYuU58miiisRhRRRQMUUUUUiugUuaKKQhQaXNFFBQoNLmiikUmGaUGiigaYuaQkUUUguNNNJ4oopoliZozRRVEMcDShqKKYh4f3ra0bUdJWJbbUNLtyRkfaVaXccn+IBwMc9h0H40UUnqOLsy3caTpVk" +
                    "4a78S2c/Q7LFXlbHsSAvvgkUUUURu1uW2k9j/9k=",
                    Term_of_Receipt = DateTime.Now,
                    AccountID = new Guid("817D8895-4A86-4D83-9CAB-44C6ADDA1E99")
                },

                new ImageConfiguration()
                {
                    Image_Base64 = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD//gA7Q1JFQVRPUjogZ2QtanBlZyB2MS4wICh1c2luZyBJSkcgSlBFRyB2ODApLCBxdWFsaXR5ID0gOTAK/9sAQwADAgIDAgIDAwMDBAMDBAUIBQUEBAUKBwcGCAwKDAwLCgsLDQ4SEA0OEQ4LCxAWEBETFBUVFQwP" +
                    "FxgWFBgSFBUU/9sAQwEDBAQFBAUJBQUJFA0LDRQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQU/8AAEQgAXQCCAwERAAIRAQMRAf/EABwAAAIDAQEBAQAAAAAAAAAAAAUGAwQHCAIACf/EAEUQAAEDAgUCAwMIBQkJAAAAAAIBAwQFEgAGERMiBzIUIUIII1IVM" +
                    "TNBUWFikkNTcoKiFiRjcYGRssLwCVSTobHR0uHi/8QAGgEAAgMBAQAAAAAAAAAAAAAAAwQBAgUABv/EADkRAAICAgECBAQCBgoDAAAAAAECAAMREiEEMRMiMkFCUYLwFFIFI2FikbFxcoGSoaKywdHSwuHi/9oADAMBAAIRAxEAPwDiegOx6nOcanPy4rgSxTUEElBWyESvArbfzceONcbNPNMQI+0+f" +
                    "Ho4gFOCTJjqLviI5M+RFyuNsRIhFwRHjbb8PESxRlbuYRdeyQ1Tf5QZbeX5VlQ6vISEbsSjNQXC3WB5Jyb23m+RWkPISu5CVuBMUt8yQw3q9fm/dl6hdbVAUdqtFklFefGK14RIwbT7zPIBF8SLiZN8mibt1G4SHALOnKnVD5oajqgwbYSzOZp+bmkepUCRT3KzK8I3VCge9OQw8OiALDnxELNzYsld2" +
                    "jIK26uSnBPphtUblV9X7v39/mipOz7T265XKXTZkqfVfBNR6rmgdwmiAGCdlsCLg7wiJXOOOdxE3aQ23E4SuvYeIeyylpI/VK3LTSMpOzZVKfrVVedyzkqnMiKT5cdwUk8iIWheJwi3CL0izuCP0YuEJEQ20TyhdiZdMsN2OqCUszjT6zSqgl8enMPNNlCRplx6ZaQjtvjtt7bN24JN++uK74rhxdA2c" +
                    "tB2PWVJziBKFloKXWCcZnSzBAdbdk7shlRPb4p/N+IlcI8rR7i9WGN9hnEVFRR8AzQMo01zM6UxysJFn1ZkdoJLZtsum0Q22d1xXDaNxcuXLldijtrwIxUu+ps9UZLSq1PWoNwhcfjwSjI224Qc3C43OCO5cVt3G71WucitjIXvD4b2l3PGS8sTcjNTaotSppRHpMlFhSxF2JIJsXHXd5wrR47hCIl7y" +
                    "4hFshIhwRCScCTZWgrBMkj5yokjK+XFyjlidmyifKA1d6oUamyzajMJYSyJLsRlwL290hcaJsiu3CtEgaIpwMnMhm4UKuR354/0zL+v/tTRJtNc6fZWykVNplIeVlidU6q8+9EERtbGIIEJRibbIm+REVvEhbISHDVdTbbEzL6vrRqKlXtOT3xQU0RNPuw+ZiqcwdI+ZMBjaSrp9+B4/ZDzqmsxsu5eB" +
                    "ZTscXKqq2bUeK240p7fqZcIRErRuteG7uuHljKU2PxNCzwk9QlSsZgSPCZCRKqYsPtCaHGUWXU/R2rtE2I3eq5l7u4jdjvDMhrBjDMyyONmc5QU0if+W2YUi0pUMXBkNIIiTZfSbl3xfhFu4eQjggUebHE5nbCluf8AVK0jM8GTMnVPMUdZVIZYF5gIoiBoIuXOK2BcXLdsrhLu2yH4SxVk0TA7zkw7" +
                    "4btFHOuZHQqkNaa7JKZSGJNRFxx5UaRr5QdGUhtl53k42DiCN1uifuiK5bmMqdUjF0jr+UJmTocNvLBR3qiDjLlYq5DIitusNxyeddjNKJqyqMBc46RBp4hdpwUeFBkMQxzwIRmQMAw5+c1OmTHMygdSaz9Q81OuE8rKuUuSU1vcS0dlXYTdl3HiQ2jxESERxAUL3Rl+/wCtJB3ORYp+n/5ipQ6KcSC1" +
                    "KmavVRpz+auNyI9W8cLZbdrbRE4Qt3XfRla3xutwVrF9KxZKzqrOv/lDZzW/FMVA2mpzi8ksilDcstucZH3YiVtw3CRXciIu23EAZ4hfT5tY1UeiQalHWHMJiFJZPxcZ45zbSwTZ94TmouEVwuCJEIlbbdy5Y4OR5lltEI1aEXOokmhPwKbW2GKd4uLBZbnybZb0ee42bljrjg2i1tiPK7kTZCVokVrI" +
                    "r2BIgzfrhbBr/wBo3UYqbPiVCqOA7kqmTWG5hVFg/DSY1pXPuWPDtkT1rlo2iNpXW2lcVMHbGsOGDBm9O0o9KektFDMdMqU2PMhyp9SKpR2ihNnSKHUHHBbbccaJ5ncI/diLzZCRbfw3XGZyeBB11J3Y+r+6s5J6uNVBp+DHk9KY/S+nDMnvwBapkuM5NbddbIRJx8yF4WhVu3b4iL3wkOHago9JzMLrm" +
                    "f40x35/smZPhbrhszNUwXLTQdfvwuY7WeZV/ux0PNtiVZ3MIR3HG9XzY4k3J1bUFISEhuG4uLnqttt/NnAYEO/fWWpbVUiQhepsrwyRmyO55BI3UuuHuHiXp/zYuMZ5nHbHEG9Oa4FNqslJZm6M/wB06oXbq3FdeJCJFcJfwkXqtIeuXy7D2lOlswdG+KF36gdYrCQIdObntyXBceZkRxcJm1tzdcctuG" +
                    "0R3ritIS9Q4E4wMtGqX2fCiRzc55Fzd7Nkx+XUxped8vxJFLbgPELb9QCTMJxOBFy+kVxy3tIfThLNgc/IzUKhq1B7rI+lNLp9L6Vwienvxq3VYDj7DYNOaBHblviy2RB6XZG5r/RtuD6sFGS2PaLW4C5zyY/5Zq9cqE6oRmI8yfGI3kjtsUywrbvdq8bIla4Ql3EJcrbrsGsRABE6mt2P/WSZbyolNn1" +
                    "SK+UN+VVJpvC7OlDvube4L1wj3W23EJfFiLLNsMPhlqqtSc+8dZ1Aai0l6vBUDgMx2mSvjhcD4aDaLTlw3ci4tldyt+j7hXBycaxwoFTxNorP5rJsstVikR5zdNlwfFA6jMf3hIVpXvPCPhy7WyJsrbuJEI9zCp6kPeLNcRow7TKer+fqX1CqsR+jQqpSqeTO9MgT5xPNHMUiudbbu2wtb227hEbrSLjd" +
                    "bjUpRqhiY3U9QLmBTiNvs99XYeT2JmXKkkSnLMejFDzIKNtS4rbb7LjkQn3OIsuC3+k4+kuJcRW05O4jPR9TqNH/AIzszKoyM212phM28zozCcWec9WHo8a60oTjQjduNuNvE4PJwtvuK4m28Injhp6OtmdvnOXPbqzRVK11OpdLrkZ9mp02EkoUOeJtMRpLbLgMJHH3bRibb5qepE6Lrd2loiLvTqAuy" +
                    "zC/SbN4gR+4nLsvS5cOTCXviCZi6Cv9eKGO195U1X7MRzGJ0XJbqtFpui01tyHHhky05LgtoRNi2Oii4I3em4uX5bcZYxjgxwM+eRPeZCQaCSxBbjg+iNPRx1LTlb7r1EJEQjaXIePcJcbL3wZV/TkRYyzAaZrposkYpohCKkXHQuIlcIlcQl6cMWeiArGGjnWcyQ4FOStzac0D8MHWZtqo040Ljdpupy" +
                    "G4S3NwRH9Z6fUj8BE0RjdT8UR+vFEpmT+nThQ3EbCu1SIFKBsbRdgRKbHAiJfV7ww5L6m1L1KuAqcNiOFc4cx66IlNoHTqGwlPgzJb0g4fipbm5cw2Tm4LVw7dokJcrrR3HCtIribuwBJ80W3YA4WaHmecdQprEpyrQ6g20e8caYomUb3ZCRAd3IW7myEXtwbeJcttvFlXHGsmztnaWzl0ulP0UnyVS9x" +
                    "tNOP2v7jol7sCIriIhJu7u5bd13G0QDNnEsSia5iL1kZg5djUSoQq1NSdIYbk0yl051qPEhCPu9wxt3CItt4bS/Z3CFu3DnTbWFgR9US6wqgrYN39I+FZW6YVqmTci1mPX4rs95ZixlkjEjySBl82XnLWnOO44TLhbzlwtkyPaRDcS9D4gKQNFoNR8Tn7+/NMtz5So9JzNLhxIbdPZjtx2lii+48Tbmw3" +
                    "feTgjq5dduW+7uu27htLDtZLLsZm3oFYqIuaaL564LFY20PqznPLFHgUuh5rq+X6fDbJGmKRMcjDduPObhWlycukOWl3CNvwjihrQ8kRteosUYVsQJmzNlYzrXpldzBU5NZrEtRKROluXuuWiID+UREf3cSqBRgQL2NY2zHJis+7rquLGUVYLlHcumBk4jyDEhwHxIWdW1qG207Bh09pHgkuAC6GN39I4" +
                    "4Pddy49pXCN2M4P85puPYRjGgSqlTZd6q2u8bYi+SOMgPb5CRcRt/1xtwMtqYfw2ZWmLI05S6tf4PdNtxd0kcLReXIbhLj+a23GgBuJl4wY1sR6dUIM2A9LZJ0jWbGiQWS3pV5CUiIRkVpOFbc2PcRXD7y5scKWZX24jteGIGefvyxe9pbLLp9VOnWSPkyZBpiLBhQozzguGAuMw23W+PHc3Bcu+Iiu9W" +
                    "E6myA59U03TDFV+QmpZ2r9Dy3NYiU+ntNlHYRoWwDZEW9CtEu4rbS7ePcPw4bpqdxlpm321oQFlSo00I8SQ5VZTFOaljICkNiJOyH7iudaFq79Y24yO56XLSIcFX1eX6oJlwNn+mL9byxPlSXqlT0fy/FYkzYLrzCStoJDY/RsDt7lzhXWj3D8LYjgocDg+aKsjs26eX1RczdmavVRkKDWI7MMqZOkuFG" +
                    "SILL7b5Wi8LpdxFcJd3K4iwxVWq+cRa22xx4b+0AU6fOpDhuQZT0Q1JslJlbVubcFwF/dIRLBzoe8CGK9pFX6pUcwVJ2o1WZIqVQeEEdly3Nx120REVIvUVojyxyAIuBOsZrW3c5MAupaS4tFiMSEyQfNcdKE4lSQ/rjpPqg591F1+7FTGFWDHj+dft+vAHMeUSC5cDhcCdf5lSY5UctvwI6q85U4KvmD" +
                    "hWtNiW47ryttK2274S/ZtzB2xNNhyH1luvU2bKrZyJhjTlkO+HQZKbTS38CT3louXXCI23OFcPHtxZGCrqIOxSz5MC5hyScORPpwiiytB4JbrbpqNojdyH9kf4sGWz4oN6tWKiK1HyoeaKzEoUFsfGz5jEcWnkuBTRwVEi/DxEi/ZLBLHARmPpi9dZLhE7tLOZ+oObc89WMhLnmk7NapuZKnVYzrcNY7c" +
                    "iO0jZtg0K8iHdjuii3ef13L54yq6kGVU95uW3Ocs59P3/tI8zzGKvWJD8RgY8ciWxsbtB8/xeeNuoarzPPXP4jEiR5bzBU8mzXplLcBk32Tjug60LoOASchISG0vSVvaVo3XYs6rbw0GjtS2ywaFUlxaVCgN22QpXi47qpc40dtpIN3aJcSIfVaN11o4tqNtoLdgNRPUhHq7U5k+QDXipUhyS4LDQst3u" +
                    "FcVrbYiIjy7RG0cRnQYEsQGOxl+XlKXFiDIciuA0XzGQqiLiguUnAMIaSBkiK8+LtqqKmDhsRVxiA5QIirg2Ys8FSF01xaUg50tcRDqJWNbhXAmOIUcSk+nkqffhcnPMaWQW46GzOweoM8KjBZylBkA8tTqMaCQmtzkRx64myJzb92VwjxEi+jIuNuMpAD55pWtkitfdpVzXRWFj1pTjvm61GZfVhGl2m" +
                    "i3hbcMvxCTncP6z8VuDIxOoi9i6sxYRTq+dJ2WqgNOiSGUQk3kOO+viREbfdujbcLn4hLkNpD8WDogbmLNaauMwlkKuO9Nc9QcxpSTzLNjOHDp1MKSTRSycaJm8S23O3cJztwLqB4lPhjyw/SsKrhYfNrE7NHUJjq/wBbqTWfEMUhyDTSgvU8SN1WlXfQxBywb+JeZcbbkt+bAaaxWcR3qrC1e0bToD6" +
                    "uEQH4pCX6RPPXGoGEx9eZ6fyy+3aLgE2SproaW6f164jYGSVMBlEXXXTRPtxOYHEPZUbjx6pGOQmrIGiki/WmuA2ElSBGKgNhvOxetPWnpvnLohRqFTaQ1GqcVnQjFkQVtUG3iXqu7ixi1VurLhZ6C66pq283BnCNdFtHHLPm18segXOOZ5dwDE6cuiqqYMO0SaBpC364PKAe8ougqqvliIUSIgVNcCf" +
                    "tJBlJ9tU+f68LxlGkG2v246G2mjjmt7OVUnZpIIYzqJDjqqsqKoLYPsMtODb67nrbbbbR4jhavUDVoa4WnXHtOs6V7Qgdac8dNmKlTgqNNrARsoSaczEGKkdxyUwTio7omqNunFeFVHQuIl6sIrQ1an92Ot1XiWLkeriY909YyzmnrhS6vmpqpP5Wq7RvClLYLdHRsNBG8OQtGVppb6S5erDx2WnFfq" +
                    "mcvh2dRtb2Ma6/lwaBRGs3+PjTWaZR4mYjjRBL3Tz7UwmQIi+u5uKXdb3fs4VZwVx7zQSos4fbkDaZp7D+TWc0ZnzpWJouPpAp4sAqKRKbjxKXz/XqLBfxYucg8RlVBIU9sGdPZeyrQ1ZSEzCkxZsZ55+VLcdFYgs+gBS25HLhK64vUmIJaCRa84lbNFEZZqziiKIiRxBUJE80uc/y24spwJLqMxLyD" +
                    "mmndMurjUoctRs2HHFzapUllXAMiArtW0RV493mmCOjWV8HETSxabeBmZPmPNbEysSpcdpuKEh1XAZaXyC5fmHDFdeqAGI2XKWJEGz8yONU6I6T7Rg/eQIDlypaVvn9mCBRmDNuBF+TWBfJUVxNV8088XEXNm8GzW3kbccVl1GxFsjNW10FDG5u74bh5D8WLHyiCbMGo0rrtg+ZcuOvnxG4v4cQGxLIp" +
                    "aROsiJIiqKKqKumv+vtTFw/sZOpxmF8mdP631FrZUfL9OdqU8Y7spWm/SAD5kS+nlaKfiIcVsuStN3PEPRRbe+lQyYszoLscG1eYdY3EUwR0FBVS5R/6iSf2YhgAMiUXKnBg+1PtwGHyZ+o3yH7J8pqJGCsw6ZHKWEqfCqWTpkdJ4gy8IMvuA03xFx5t7iXcyGMUJaPMp/xnoy9Jwp/lCfT3pn0Fynnm" +
                    "p5kjZsoVe3Joz6TTYErwIUZxGgbcRi9xxzQtpkrbh7beQ8cDstswE1aFrpoDFg6/wDH3mNv8luj06jQqZLyqzmtuHIlyocmp1NXXYiyZRy3FZNtAUFV1xS1HlolqlxTAfxNg80ZPSUsPMMzn/2z6rlXIfSOk5cyvS4mQ4qR3WWlhNk6c9BARaZfdIiccG1shFwi4kojglFj2Nl4DqalqTVIt/7M2mRKV" +
                    "0/zdXXKQ7UJD1cZYZeRpg2wViOqkPvGy/3svIbe7HdVYyMEQy3T1h/MwnXVPzW/42qSqL01pcWsVRltma54KCwj9pOFcaIBKV28RaERdo/iuH4r4wTD+Gg8wSCcxdIuoOfolFOVScu0x0XUCRHjUinGG3oIjeUiP3Njd9GX5sXW4qe8G/TFl9OsxzNvsrZnoPVdaRWem8TMFBmRXDg1/LUB82leJorBf" +
                    "2iEm1By4eXG0m+VtxC6txAyG5mY/TqHw1eR8xHXpP0Gg0CkxAzV7Pk+mpEUAqFacrk55tstRtdGIDq3AJoJFt62iN3pwFrrw3DQydJ0qqDr/Oc25g6efLtTGSnR0aD4tNxGlzBPieIBCcAX2d900FCFsfpPU3dbaQ3NPcFx+s/yxRKtsnwP8SP9ptXSHoVk2RSiaqlEzflh+WAtOi1XAliQi3t3N74sj" +
                    "2kQ8Uc4lbbbxwg/Wsh5bb6ZoV9DWw7EfVHOteyl00dpcoGeqdepLEuPGiOhmKgUx0LYw2sCZHCbElbFERu1bhRNBK3Fl60scgfzlz0CKCGIH8P+P7JnOavYcr875Rq1B6rZTzPFe94wjWUqQjkhwpHDfe4tkIpbc53dwi36SsOrTA2H+aVbpidihBB/YJk2Z/ZM6jZb8TLj1jKb9Ui+IiuRDocYRfZcM" +
                    "NDaFuM4J3bZem5BIfttwX8ZWz5O396A/AOtZHESqn7Nmfqll+YMr5AGUINPRIrUKMDLui7u057ttxsiVGxtIeV3K23FrOqR/IIOjo7K33OJn2YMmdUILYRJuQnZzbNzjDceH40GhK24R2TIR5D/AA4b8ethw0T/AAjVlVYff8IuD0lze+KOrRJramlygVOloo6/UqbPli/jCD8AjjH8p+gIZsluEhnQ" +
                    "opuKNmrssLrf3RLHnNF+c9H4hPwyZa5NlkplRKDqpXaS3zc/ws4nVPzNLl2b2X7+mW4tcqLKqKUHJqAvdcbxXfu7OOKr+ZpAL/lX7+mKXWLpnE655eGl1mTSaRY6jzDtONwUimg2iQDt2lx4kJfEXK7liyOKzkTrF8QfDHD2UY1N9mfpbNylUpNMrj61qVVAnxwJBfBxtlsBIXO09Ge3kP4sRa5sbIE" +
                    "tUBWuGPM2eL7SGVTQSdp1MjvfA9HZIxX+y7HAOfSsL4tZ94RD2osuxmVJtyCwCJpaDbhW/lxBFh9p3i1/OL1a9tGltRyYiaPoZjc5GgGSW+r3fiBeu+HjggpsPtAnqqhM2zD7SM6qE8/OptVqtNafJYsUUcppRl4kN7jcj02iVtv8N1xxSfnAHqT5mxGeh+3W3SGweruW3aw0BI2gR1YlSgDzutVwmV" +
                    "IVHX4rf2cWFBJ1zKHq17kTeaP7RXT7NNMV+mnGfhPAiuNSIysLb+IHBH83bxwq9YU+dZoVurjKtAGb2unPUimlGVVpD0hNb4xWAt36wOPpX02934cAKoOdZZgcY2nKfW32R5DcKt5kyFU25pFLbWPD8UrEkozjYkWjltpOC4LnaX0bgj3dzyWhfK0ybujdiXrM5Vf6jdX+noxznVXMVKiGhGzGzDHJ8" +
                    "CG7uHe9Nwlby5aDhvSi3lQsy/H6rpzhyR/T/wC4bpntcV2IbY1mlwayJkhG7HujPflHjjj0a/AcS6fpSwesZjrQ/aZyVVmwSakyjmS+XiQR9sNV+Mf/AKwBulsXt5o6nX1E6txGlOpWTT5JmWnKi+f0Z/8Ajing2/lhvxdH558zVlTyQtMT4cFvJxrJ/Gv9i4r4Zl9zPfyw4vqX+/E+EJ3iGRnVzL1L" +
                    "iQgE7cyFZxOL5r/fi4UDtKZMjkloGuumLSBFqsyFUFRSRfu1/wDeDLFnaK1+6/baC6/NeOqYZiYGTC0lwtlGZjbRogil+0Oit2jaKafhwPAzssaycYaL2YTdSMIRnXFfFCRTBV1RONyaF8No/lHBl78xN84wDKWXOoMvJzhvxECMLnB5plSFskIh/RjxEuI9o/4ixd6VccyK72p9M0uH1Imqjbrcw/N" +
                    "EVPPTRPn88Inp17YmgOqPcGMtO6sVNkFE5Ski+Xmqa/PhVumHtGl6pveFqr1JjZupq0zMDTFSppIiLHkAKinEhHz/AAkVw/CXbgJoZeUPMN46uNbBxMYq3s25aqVNiMZcqL1HnlIK599wpLSt7o+nQS4tkYiPG4i5fhaHUOnqiX4Otx5eTOe855Xn5FzQ5TJ0V8EbMkalqCCL7dxCDqIhFoJbR28vS" +
                    "WHVsDczKuoNYYGDLo/6tv8A4eDZin6ydhMuKqqmETzNyWBJfLzwKW2MmQ1XTHQoOZP86JjpeQqai4qJ/wA/PHSrcSCTMNoLtBJNPm0xYCC2METZqvNcgFR+xcFQYgiciLkyKBFx1DX7PqwwDFj3nwNE0Koji/N9q/8AfEToLksC45566fYmGU7Sjd4uS3wbq6RwAtES64iRVVPsXy+7BB2i7cECF8uy" +
                    "DCGPmqqqqmqr964E44hajxGFHiRURPLTAMS+xluO8S2Jr566a4GRDK5lpZDgiioZJ92vli2gltjJZNNh5kYOj1iI1UoBWOqLtyEiqJWqKoXEhvPQk0XlgDjXtDINxgxIl+zHSGpTwJW56oJqOtjX2/s4nxDCjoUx3+/4z//Z",
                    Term_of_Receipt = DateTime.Now,
                    AccountID = new Guid("C370B962-0EB5-404C-B3D6-8373B79FEB92")
                },

                new ImageConfiguration()
                {
                    Image_Base64 = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAYEBQYFBAYGBQYHBwYIChAKCgkJChQODwwQFxQYGBcUFhYaHSUfGhsjHBYWICwgIyYnKSopGR8tMC0oMCUoKSj/2wBDAQcHBwoIChMKChMoGhYaKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCg" +
                    "oKCgoKCgoKCgoKCgoKCgoKCj/wgARCAD+AUADASIAAhEBAxEB/8QAGwAAAwEBAQEBAAAAAAAAAAAAAgMEAQUABgf/xAAYAQEBAQEBAAAAAAAAAAAAAAABAAIDBP/aAAwDAQACEAMQAAAB+SPx8e/i0mw8OtLxVh+YI6e1h6dBjsFePypVPVXhNerfMFki0ElylTJTYskjaOszLbuWYXLEBLBD3sLpnhWC" +
                    "3NYjA2PcMdLNoiwq0xMvb4pwWYMaLlaypgs6CxDCYrFMQlg+kqQg4QiNM3kHREtRSnOlYWZepuEZ0hLURgdEYkRkByZgZEQbR6Ot4CXQqcvefZuMpbfMCqE0toeJQM8iVsVXmeCXpWIhhDjQCQZuoQnZJihGk4nVSc9NEYtLD05X5uMOHJvNIMX0Eh5aO0FNfHD7NeoKZnDpSokozc0q2eWT4GUBF9FPJ" +
                    "ZjahLMa6BCFgRajWSHH6KOhHZjbTxnPWnpFgtxpkPj9XKXocJidSA/U0bArnse2Y/TpDtyz0KpJaUtHT1IknJTvVRZ1wulMeNOw8xq6fFWLZ/N6ZA8ejOlFb5+tDFv56wjbKfUa3H+X73yvp5WUrp2DbzKUppnDRRzV+Jtaa6DndOceX6umAzBYjF8pk1mVDCGGeWdc1zCzMdzLS96mccsWY9HpQ3eXqw" +
                    "pZ16a54+mfkU9Dpejnwi+jS3KPtLTlv6vP1mRPWCufa66pdBtPdEdWc5klK1aM63fa5PElGNS+eLW9BVU8yynOg0bqubZx6dZ/Ebx69mSROimRiu/P5qvf0fj1/M0/bfE7z2Pc39G1n43f0D8y0Vd/iO3hnP6A4QZ+g8rlr4zyh6lspZvI+LE2PIit9I0nqqAeeQFrDjdMyxqCRZJaJsH2d0OXRoU1/Ei" +
                    "v634b63zdh+C+y+e6Zj/Q/wA9/SvP0Z+b/qn5P0x07JU+jHUs556x0DPeG+NPanSkpj0KVnkWm+NyQoMrTnVN6TVrM+dKZBh9TUd53WpPdAsakZUYx8/tcuFFKHTFc3o8uX8b2dfRs+a6Udb3ptlFXHu5b63lK49KGc4fRzKafxOnH2szqKeKaY3jTP4qOdvP3z+jDndtZsrRPjzJYStl3leGiQklfmM1" +
                    "J1ra5yO0suCH0zOb81F9eovi3dC/WefQ8dEfL7k88h75SpAKIiHoJSZr8GUnllTM2ffLrrneru385TPan9GtRrJ0zMIRlrHNrwfjWslZVJDvLdwyU82sFT51xu7831e3JM9iNXneBlcrqzdOenmaEqrygTYJK0sLhQ0TvNjwCmVc2+a+z81YvcUg1brBN+MPY05kxZaAzMuLqQhNh3RYpHq53Y+f7Wstxf" +
                    "rTfJZGDQrWVAc9GU7KsXKEVZCzN88ogedM242XwMp10jq6IzQOvrExTT9CvwSTEUCrRUr83ze0MIgYNcHscn6MxJ6hcrOVkvUaUyOrmZrnwVy+cuQnTldxQWO5Yxyaal3caopaKEhGutAGL9JFfz7U/Y4HYDUhz5+rWqbVtvz3ULpTpVUXX+a79OnVOXruF2KoXGVP4oeCu/ndC1Pztms1wtVHve8nqJz" +
                    "rwNCsrX6hA8q6KuCuxIUksbLkXDO2e1CiGaOnxO1Ubuf4L3zO08/E2ZJu78/2Z1czahBfo6PQ59duObo8mz5bV2f/xAAsEAACAgEDAwMEAgMBAQAAAAABAgADEQQSIRATIiAxMgUjM0EUMAY0QhUk/9oACAEBAAEFAh0HrxMTExMTExMdTMTExMTHJHRZiHiYMIgWEesQf1jpiY6tG9X74mOZwZuABaF5" +
                    "nj1CD+odB6DMZhWfvb0wZxGwZjHRoc7zx0VczAn72wrx1HpH9OPQVzO2Io5eHgk8mAmE8FcxfZRGaGE4m6YntN5jdR6B/XmZhM388iA5n/T43YzMGNP2xxLDAODkTMxiDM3CNj0j0j0D+nHU4m3cwhhifI+x914DHMOZiZ6Z9Y9eJiYmPRmN7M2B7wCYE4E5hAn7IxBgkFTMoYcQDoT0zOIfUWivk74hg" +
                    "ggg9JM/WIw4OYu5STz3TFsz0VFnhGVcN7DibhGtg3GYInciGWPi5vQDC3IPkOIAWNUHQQdeYScYyxfdZu4Lqs7nIO6BWJ2xazkuVgsmRH5fYceJUEsVNYbuCNsgCkP4i75VndV1T5WDEbEUiIpgwCvQQdeI5EsfYO/yG4AWybFUhwF3gxeCcMLS24StjNwWx7C0qZMIZa2Y/iF9wEAY5lqEnTAiYmOjSv" +
                    "LwoUOzhEMTAiewEA6YmIRLMzUW73qUZ7QM2hDTh3bhlRVjhTHErGW7M/j8cmMhAryIjZhfEbawVJc2BjiATExGadzITO0F2JKqVYkVKcgqIpBgEAgExBPqtvbRFYxKxAyg/v2gwoZxt38gxHCxW47hwzNg+Q7DOO3hFVoK4BiMdzzjpuEEzhrRNOchrMkooHIFZYzEpg6BuWbAWz7Wtt7t4YzLEDdt94W" +
                    "MUWtNpxaBh9xCExAdqriY8q3Cyw7X4YO2wtbiO/go6IYWWexEq7bKymZ50qNmxDCkXCwYMqglgJWveEtYMutDGqvRrE01IjU+K6YmDTCdpcv4ge9oFq16Ymfx8N2wten3XL2yrZw7ZZRnFy7iAMWndFXggYQQ8SsDO9ZjdFc4TdEu8Q5njNhlVcBxAZmWLuir936jhlFe5/4Nss09laoMRGwrWubEsfdY" +
                    "xE0ndNjWBJbyHZu3v7ddaOJZdiLnLNkZM3AzCzcuGZRN4M2MYfEYzNgALACp+UFeGfnuiJcJ/IndBgu5NnG6bvPUWqFo5u0Wp0Yq/wAhsofojef03SJqE1ugro07nc9Xibua0XjsizX036IT6tdp9lqbgvCgBSM7eCpUZtBE+UyFiOxmxmhrnLQV5OwAKngeAtmJ3MwKRBN3K8wLgIu6OK5gB9oGl/yYKr" +
                    "Sv5aCjdp7aW/8APU+aMDZ47amL17uFqbfqFSOmGcQfH2Znm4kFiAMYOzAwILYbOG8JW+YNOuL22stbMG0424Ii8hZ+0MHMbaq6i7ihtztqF/j/AFG7+Uz1rE4s+nH/AODUcfSQCXrQrG96SNldhzp9Ugu1xrtYnYWmGm6HOKzPGWbZhzBUWnaxGnZWNXCtmFcbmvAhtMQ+akzmcwbpl5l8WIpdTWQH7Zu" +
                    "fIzwzEONfcFTX3NEZKwrsYeITsjnbWiboXAigsrDxLhZ3VhsXDNCzZ3yuwid2b5nlLsqmbneoEPUIU8sSuvkKIBMQdDuM1tfgNLao2XKdsc4meglbgEWYjWrLbVdzqKWg1NW0OjQHEe3xsO8Y3Ka57BxNpgWAbZnke9X4tPbsu7i7Kw7g0zEEzMzMzCxiuZrHPZhgTgoDDp6zDpKjDoVg0JjaVthptmxh" +
                    "FrXFFVBltOnDMqVA2mNaZVfsBu82JhZpuaLYZmbjBYZUftVc6nUeIrYbCZndMEeoS4RDleigmFJibRFSFRhRxaC+varll2yzDoKQQdJkHRGDTs0FTKU00dcTZwK0YbMFli6eVGUf7Gt/Hos7bbTsqwKy0b0YnMubC1N9sETxMQEQq0AczZXtCosUxgJpK+5rTUgDjyIiLziWHatDE1VqFEKwJ5YmMtgQS" +
                    "v5VnF2ofcui/Hq/hpLz22tXYjbzg+jE2LKK+OzPgVsgszPKAmAwSwqJ9OYzPT/row3BKwg9GJtnExD4z9n8dRxTY329GMrdxXQAKTxM+kdDzNsJxN8DQPN2Y58fpvw/qUc9MCYl0X5Wjaqn7bHM05xUWPZ0lrdvvSgbxgejMzMzdN8YAzBmZum6aI7bczMz0UZmIZgxztitnoXM3mdxs7zi33Xhrzmfqa" +
                    "c4rz9nQe2JpL/EOME7rMbRnEVgeuemZnpxCs+OtyfQrYhsxDdO/LH3tV7Q8KuGBGDa+A/vP10U4VuKNIdq9z7Wn/L/AM9zt390QuMaYggrCDF5bbMdBzMGYmpBGq28YMwY7Yi9AuY1cu8Tpz4x/wAelY77mwLTlm9x0H4+jn7dX4S32tP+VLczVH7jDxwZU5F5cgd0401o7m4QuJdYJSwNeRLGAV2y28id" +
                    "wxrDLH5q+Jbyd9sW0MNV89KfCWWYNbbZuLVwwdK+VPBhOZX+NQNtRw1B8r/yZG2xsGv/AGmIhM0pzqD7ETUnE0vFMt+CnN7MADYAbLAsubJ05+3c225yWRWNbaj56T4y/wDLzEPprOA/y6UfFIs06eN35LrNrE77wcX2vxmaL87vhmu8NQclTt0veKmyzcND76v4O+57Tuc+2m/Fq2GKn8bjl3OZpfaaj" +
                    "g9yE+ke1nv+rPjWeE9q/kr+LcnUHK1fM/M/HM0hxbqH+5nhjmIw7N3zX20RxNUc1r8rjw007/a1DbnbCVwzTHjcJZhl/wCn95//xAAfEQADAAICAwEBAAAAAAAAAAAAAREQIAISITAxQXH/2gAIAQMBAT8But0pc3FKX2vRaL3IYi4gvS3ClKIp2wmdiizSi0e8ysXRYhCbXe4R9FhsqPBV7YccMpDiqd" +
                    "EhJMaOvgnmHUmi0WPIqzi59OPMYv0uILkN0hdkUo8I7FxxWH9P4V4gtJileIdRcDoJaXKe8IxZ/Di/A8P0oTxc0pxfgpS+hFxTsJlLharD9C1WFlD9SwsfmF9yh4//xAAjEQADAAIBBAMAAwAAAAAAAAAAARECEBIgITAxAxNBUWFx/9oACAECAQE/ASdEJuCW5qag9UXgxFtdL8C1BLbF0cuulKYqixh" +
                    "N8TjuEHpIkEqZKF0mYehPouvZB7gj2ejJlKLIvYReiCXVDuNEg2JGGNOLOLODJpLpm4RlPkv4fWzHBo4/rMs3iUfyxHPsYvsZZizcosy6unuah2fYcR8yeU4o+twz7GPoS7FFlX3HhfQsYXbu/ZxPrOEMVpkEprL+hC9H+iWqN9XFHFexMbhyQ80cy7mpqddF8iHfw7noXvsZYtsQkxeKQfc4kaE/5RxT" +
                    "OE9HEhCeSEIQmoLyoT6l5kUWvzwf/8QAMhAAAgEDAQgCAgEDAwUAAAAAAAERAiExEAMSICJBUWFxMoEwQKEEE5EjQlIUYnKCsf/aAAgBAQAGPwL9qdH+9bhfBbRGCYR0/a+R4njsO+kLXweD5GDH62Swux5LCWj0bLjZESQiNbl/1r6fZSSNssVfyMwPvrbJeNIMfr+DyWKSZHpCGvGkQsaYLW/bsjI+5" +
                    "Hcsj5MuOckrJcZjSNHYvp5/VtgzpLx3GNLSDmdyN0cW0TfYk3epMnM4MHxE+KxcbRY3ccfTS6Io31H+C7U9hwyxzYH2I6lzGinIlSOqrC0sS6d5k33SVgtqn9cF8eSVjuKqk7Hj8FzqWcNlp9l59kJ83YipX7IuiOo5aMjmkuXSG+yPBdEwoJRyl2cpksVUvg8HjsRlSXzpfjwSQmczFzyfIsz5yS/kM" +
                    "s0y75Tsu5vJyuw20eiY06olNGbcGdZT0lEJWfUiSOmtuKF8mTY53HginBeBKmw3CdYlHkd/JezIV6n4LshaQi9LP+7qRXAvH4OxK/ghjoWPBMHKj5EmOBm8N9EWscqMF8aWmRf3FB1/wKqS3UlmVfSET08E4kvzGLcNkz3rNDsJr+CqVp4O5ykNPSw1XnoWZu7O3s/1NrT/AJMr/JyIuXPkRQvsnqje6" +
                    "jUWsXwVOehS9mnamHUyJO560lZMFi5Zj0lsjTlsdj+Bik5LE9SNcm435KCFllt1/wDsjmVvZO80LebjsNrBep+hpVXjJNcQQWc0jXV29io2Kqf1Y7trqXUdBwdz0X0hfyYWly+NMkIvVUSnkicEcGRvRVN+CIyU+zZraVUSl1F/0zpatO7ohvaOr5PD8j2lFVTaaz70WEVOboZsv7qf9tKahre2aNn/AGK" +
                    "qJ3rx6L/7h0nccZyTaD/iSjmzpjSxZ5LtF2f6fN7HNjBi/gvnWw4OYW8WR/T2V6qSlUpKyx96Ir2i2m0pa3ny1R3KNrVt9pVO7yt2yhlKixDfQVSbVJEw/JRvpuX/ALWUy5p6WhowxN1YJfUnssHL1L6TV/BgzB5LkdYERU2xbpNZMweCzv3L6eC+CKVopNjTT8qGnAntVHSxyiXk2/qs2a/8P/pZP6N" +
                    "5qDfqh0u3rScrubCaqdylvxBu0bSaN7eRvd83Gs+DrC0v005iy0vUZJLzJyVNCe+RVzedORuC+GW1skYLo50Rs1BSlMl6iJzhmSJt2FS70+2JtKWNtHN1NpTf0btNvrA2XLM8l+pzGTlWuDGjkkcOKUJNuxYRj7HvLj3sQWaJgi/shqKuD/lUS79j0bOrp1kfN0Et9W8k7yf2SlYt9mXGckvRrgvrT6Kq" +
                    "ejJJwifwvguj4IwWqaPmPdeD4kOn6LnMqmJOl0p4qke6mWbImxdz4IixLn0TEaXHCRgwUi9jKY0sX46ZdmUtdtcFnwRGm6naLmCERWpGlKPkz5D3Ys4MTUTWyFp5I0yUrwL3pkqFu6W4vTF4trZlqdOY5amZQ5SZ/UO8U2PmcpCX3q2+hGzz1bO76vRk8K9H3pVPcsQ+hJZGODOlW+uti1SLotwYLxptn" +
                    "OauJpqxCmPx/ZWUoqGUpdvw30xwsr9/pUoelZVJ603n+DHHtKPw3/Aha1lfsrGOl6Klflt+J/gWrF5NoydaW9au5nSNcltdm9MmfxR0J4XrSjaCQh6TpGsPrrYUaSijvPFHEkVMfC+Csb4FIkLR8EC9aMp8MuRooEJjgjR6W0jietRVpvDNn2LH2LWPAmIT8CKis+xaIp1sIem8YRj8CKirR6U6MR9H0fQ" +
                    "tKU100qKtFrSJFtXxf//EACYQAQACAgICAgICAwEAAAAAAAEAESExQVEQYXGBkaGxwSDR8OH/2gAIAQEAAT8hOCBBAgQIECBCCCCCaSkrKqcwVTNYkYGOOZov4iWylf4wWMVdCbLPc6tS7mWVWZ64iETywhweAQIHggQIECB4EPAEaO5S7V1uIK62S73M88NylOoXtuKVBTJseZSW5hftTE/9iUHdy2TlU" +
                    "P0PUbCH0g73qOdOIkfjwx6hxBDwQhCEIeB4DLg+48b/AFELS/UxbsfhKwMxy/Uu4pkrH1Nx55JxRjmy+LmsMquHnuBfYYKBxDmE22hKf4RbWHwS1f7RC2EfFTSHgh4EIQgQIECHtKlSsR9sI6LWmG4hd8GZ0QrKZqj9xj0I7FMde4j4t/EwHllEPqWqfGZroVKUYVDU5rfzL1V/UU3ZC+iFVKZMrwPB5EI" +
                    "QhCExCvHLwcSo4NIuS1rMyg12j+B/3GCutS4sPbDR+jMNtlCViOsTBrD4lpi8oWkqLXxKGr7QQwH7i9B+I7FP1FqZeGL4UuEIeAQh4EPN+HUW6LzcyMlrJ6hZg0am7wE3Ll3rP1M46YIcCKhuDZY5gNrGEZSy2tMtoHL7m26q4pXI4htYwgaMtcYjwCm5bG0rwxIQghCBAgQIQc/C0qVLo9RoZiLVs1F2C" +
                    "+tEVZyrD7iUzRgrl6SgT8EeiEpVT5iAgvSWCmmzuFYq5iW1XzKGA9Eu4rFwKoK8xo4lii3BK3rUreBbmWP2m0fBCXUp1PjT+ZXJLcbf4/xAqVK8Z0VB3/uc3cKcPSYGrDara7eJkC1CjjTXHMqsN7v3EWWmDe0oX/Ijhglgp0LjvDHCamO5mkUPwlFps69wHseuo2XC4qNlOOoLlp9ReMHMGfUZU4mD4lt" +
                    "FZ1Wp/wBW5S0mQM9xOM+ULC4paEqaf7TMpjimcJXuepLZAQaTMWjAmp7x2uYRBbSsTDFvMc2j6TpB8xhH0GDrGOe2Gcso3lln1EUL2Hqb2bCp01LQOzUsDIuK1GOx6g5OWaBU3ztoy8t1ksiCuKgnWPVLOhsjLdK/Ma7CEhqpnzAgggSiNCMioufoGid7bKlRWCMWkH2+IBUIAyJWO2YttbvURCNHT/u4N" +
                    "KONw5sNBe4i9DNsKAtoPvMVS30lPRo3BvA+Eo0v0TIxfmbHdsIxvUbDKXgSqKDkjBGtFz30ZURQ6MQBT+RBWyy0EEZX7hC7r/MDseQCEEfIlXCtAToI/udcejEcsw6KYb53iaqKLvuXpAnioPv0z7gYwPdbimsdU1EYsTVdTJzYcqi8IXtECkVsLiRdDd/3GwsjV8S4YUDjMPY5jEwyPawiqCuKhAG4Vim" +
                    "V8PGkxul7gtEQWIH8w/WzI9S86HLe2XA5aYLYjCYs6naP8ASRiWz3h+IrsfaRFV+nMwsoZZTpvzbLvUH6YTthiXiv6wolsYYrMR7DmXyakIrJ7uNxJjGvwRqAKNtn6hano3X/AFTES/ViWn2KvM4Fn7Si9T4AlSukwYIaM34WFo9mGgOzah2nBMYQbdpgNfSQLNRu5aXl6ihyz1cuBlXx4lfcJw06g9wLg" +
                    "CXBFuuAgisXqORNb9Qim95mekdcw1VfdZhC94plOZLdO/xKi69RawzqFo2g2B6ljNmABClD8dQCm257x1aXYUtJh3626i5BVzN+qWY7eYtZhl2/MyEDAyI3AXMIGskFTK8EVV+lix4nmI5frbGUMwQazOQgQpdvephfgP8AMF1UoNV7V7gXkxMV7YtVBAjzoEpaZjgcIyR6lZsyu1iXJGTTcS8dVNytPVO" +
                    "ogqtYT9w06WwwppssOCkI/iDOrm+Za2lcYm6KfeLE4OH1KMB5HP8A7PfD3LQsx3iI4mn3qKHB+5k0v4gVduIhfJuIYJFdqIUjpzXMaUtDz7lFm7v7Swl4+YWpjcc2QvMtb4Ln3BQoCSlS6Vn/AFK9ZVWLvi5XHkrM6Hwf7paqr8B/iKsD3HFzuTa+5eAUrBGXql4cy9oqafipl6v4miCplCo1KD5GpkNA" +
                    "BXbEE2oVeQiVmwcrfvX1HqDyA3DmlXOYSFnvwx+A/SWf7QTW4XCB5MpcYyCD4jVi+AccQutquJcqM8k66cwtzwN0QiyMrWA8D0jSdM3Hbu9wshj1UWXdy6Q0GXW7U+ZT4UlwDaorTR8JUx0ayz0TA5tl5iWbzAi1LKcoTqGlewf3MLWR4iuZAut2+2NwLO5hWU60e41uXjj4mPJVVoqKByvvxaCyLVqsj" +
                    "VkYdduLbubBYP1LH2P4QRot/TNGq/JF7Sn+YYC/l4mjWJo5CZdvmXtflKQ9bMdcAblR/JhGgFmYSBDDjcrgWtwhi7s11MXXxMOkScBuKDbdXGoBw2XQx2HeD5gShV75m4rlVMmvqFcx+J+xLXcQUNMbppVquFVur7qAinOYUNWN8TggP3Lj0m+HzMidBOI6uFBbO32UJRo3eUs9yosrZzs/6pV4Ge8xbw" +
                    "50GLfAy+fqc891LHeJyit1BdhUmJj0vSoCpbwh0eupnuH9kxVVwVAZk7ZYnjVEtXh4hkKPUcu/lcoiLTEWDLMxo59ytqC44fKBQr1KiN299xbArnMdlGnwGVQ0Cj+f9xbWLufQEQ9DfzH9I/SKrmYsvknL+I1IIY1mEFzQp+IDFZrtLwCRixrVSkJq5xZn6uLRtwrBEzKq7f8AsdNaWSNBoLSsRuw+DEB" +
                    "/uJegX6iDU6tBQTOHg7giXhMXK31HZZ2uMFse4VCC6aIW7+CEORK0MumU4jAM/opheH5mXVzLgYwfyoW2V+4h/Zli9rmI6DincFGl3E6jC9MbFu+RL2Czkjyu+xYfqFiAprAV9ymgl3BXS9XBajil+mtkQk2c9gd1MytAfUSklXuyUtM1AYN7xxCyTpdRkuhhdMQdLYmmV9SgYI6MVal1rEdWn5gLK2i7" +
                    "K6qFEtM0OLnsEIMCK8MFnU4jCJnaEL4r6g2h+QgoHRAdQPEt/wCIQx/EsDXRg7hHKeI3qyabl8YGvyhCwDmLdsuPPqYG2/gla06Iu7ymk79zpMpDOIGLl0yMVdqcwt9VSLgD94wBLxF/VDC9klzKrMTIfx3KeIgi5BdMAav4jwLYSzhR9wjbAw+BBKWsoUF1cS8rYAxUw4h4CCSmGoiEsyWfzN5gshAxB" +
                    "sD9TdfghnH4Z/7agbr9I0TyvMMKZY56jlKzP6RFlRMZgbu5kzyGE2oTDdy7hXuNwXpGpwNUjlo9iY1IrTbEox0xF/8AdQLTx6gqtK3KoMsVhzU2U2BxEcWiVlyjxtOpxieA6hczLuWHNpEQWIj+GBpCPGZvo6z4hnmV8rOQMe5eKjB33L5DjdQeCuu4AAWz9QFxHF1FxxYt4nFDOIfxNliAuJpwde2Mtp" +
                    "YSfsmWZdYlZqved56YLYtfUsLYw80rPC3ibbYaIMnuUXpGNlkpuBgwjFRm3YJ+YXwv0ZzoB7pj7RX8zYSYRIYrR9GpuO+4VYB+Kivs1kPjwKz/ANqNNXpIt6aKHueqVZ7RSnBqNJwmFwqGaukf7m1W7OYzH0SvBewR2D1LIKxxxPx5oHqL/wCYw60IB2Z9QZ6DFa5gW4JmU9xvuL3Jb8TirNy4mR+AxGj" +
                    "NEOkTlLRmvzDbphVgXLeiCNUs4W3VzMuYsRXXo8N3qZkFLE0cRJT4upd3iIOYmUp7nLeUqXV4oOD3EWT7yTVOCcitlltInmDD3CoMXuWygoXK8Fx7mEM575SReywPpY8TubJcMW9wXwrGopHwUsQfEiLJBYIQsKleZpdTE92RPu1EV3c/ELWMFM+aCUcTXxMeKwExMEKORBczN6fUQggl42KuM13/AIG/" +
                    "czLceAeiPqhyq2QeeZV80U8B2GW368vsBBNjwZXL6iKcHkhaitpcPeYGjLHoliBmUVdRc78b8gxILiZq5QTFTPTKfcuoieokeiUOIYYjPBWzqLG1Csh18zbCLCsX4UJzAUzO0vTVEcneLD3cp0Z+OmINPMc9TRWUThEDzE1fuVOZTuIVBYHcRXZNIBQv7mGEZGBnW7jiWQhTAtqMSW37l1Hl8S3DA0Jro" +
                    "c5y8C/S/wCEHX0z7TGCPuAB1LPrLQN0RsrNShufDG5ZAcyKoO5ULRJpGTrZKGtovxEVEweBhXuKw9wwc2UV4PElxly9PgrWe4QszGZL5Gj3BYdeE28VyOBxMx6ZkHLN8c02EM13Hl9weYdRQfczt1BrMJwrPECLGbItOFj7Qq8LHsss2lSyJOdTkhOyI7D6i/PLxLrjkUykVz5PFw+4PBWLiC3VR/kTd+" +
                    "IAUZ8FOmg2rBMi8Rq3Ny1Pxc7OmV1u0ZsbZ9WjkQW3nLBo/MFp8RpJLvETIMdfFP1ZUWZ7ll71uEjC5OCfvziCkh9wVJsepc6D6/xWfzFcm8AUSovUp9cdZdSnpMRWsKkOo6Meb3HfZCWR9pgVcWo+5iTN5D4x271DynUBd7nKhgAihF1ws5USaxbbfAD5p80FdvDKqnuEMfH/2gAMAwEAAgADAAAAEFA" +
                    "DzeNDxlWwQAECil/2K5VyW11aZTp/DeC+SWo+feDKd/vrQO4WrjN5woHCVfrg266HFdOVC7tZWIaDuNPzzFkvodXcxN3p3fUL9FVqdk8LHyocCEfg+tCNtvHwpbaBI8DdaR6i73rY3NRagblHGK/UM74mJGftxm17EvbMvE80eBeTC5n/AKyIElxP0sYKkcHz8zGWzJR2FMffRAMJQL1K3QIKUr8Mu4t+" +
                    "I9ceIlSXogbt1cMps6s8p+1QYMrDYtO4tntMjXMCbEFZiWQ9crTq5wz+KDEWiKv41sOReHFqK/jBTX3lcyWX7alMGGg7a7v/xAAeEQEBAQEAAwEBAQEAAAAAAAABABEhEDFBUWEgcf/aAAgBAwEBPxCch/fAxi1hhtHho3rwfUK1EGekX8vcF7suwW8mTDGrOBkt5DIrHJMWXIMgiDyuS39b34jY5OnkC" +
                    "nY+/Db3chPAWDZBEp4OpFkmKthKbfqckuF3OJ74CTk+4WJDksQbI+riIZbCDtiU9NiQLHkERmN7Kz4OQpClW79gnDx9urjKF4hyXLOYGMbtkxbvgSXfBtp8tPyJn7CZISOsCRmkB1JZrP6WzyPZYdJw8uPc/kEhAn+Qssn5C2jskiLqI5dEexAxrKPVgYwR+pmhGNpHuzJAwbLy9eXv3LI1KYdYldnpy" +
                    "GdTyLWu+AJfyGH5AghXDGyN+KNxJ3JEexv23GZqQvkHsPYjxr5GUjexnyHekuaYvmAuzhdsWSwnj0w6w45LsD7jkTT7J+MInfvzDx4Df8tuX2YvaeofsIhf4TSfXLX7DsbLyXLeyz/B78bzwrcbYeyy+2z1tyXl6y7LvgsvT4bYZdJe3swxB3xL2Y8h2b//xAAeEQEBAQEBAAMBAQEAAAAAAAABABEhMRB" +
                    "BUSBhcf/aAAgBAgEBPxAImSWQL3YDcY18IB2AYI2dkEBOPIA/B+r8fHsTgQ2dsCxECzvbQMtLsn3J9wgT7Zn9iG2W2X4ELbP2zuR/sJZLsGFp6THssNra/fwK/URK01sGS6wvIBHJzIMCZ8bOR916viE34B6hk3yznbLhhHtpxED5PC9LUH0hPXtpOvy4Ow0kTOxPSXYD7n6WEMrZrJkMZIxfVJF25Gm7" +
                    "2HAwnS2sIzZthxtPqOS/l3yEF3I5Dj6GOe/A0nNu+tmc3ZZ0lAbZMNMg9PhGnWNWb2cQ/ttg52wOpCO2D1kZGUBT37JEbNB/2W6k6ZGMmAvRGEfSz9gfy/Szll2Gi1+wvCWD2NtrZi4CXk0CbHWa8wqZBJ5DPJnkWw5bOQvpJ8FyhGtubDgMg9hE5P4WixurDJTEMQxk/sjOweLbH3l8uSPCwXE2O2gy" +
                    "Q+zz22ws2xjvwchG+pw5CKY8k7yFkCFPbzBgQWbb9Et9R8BLDywyDZ+UzBeIdn8syG3GweX1/Bby8laPZY1jyPJnbC3vwH8D8n8Gmfh5D93rFvY5yL//xAAmEAEAAgICAgICAwEBAQAAAAABABEhMUFRYXGBkaGxweHw0fEQ/9oACAEBAAE/EDCTNS3iADguadBMGI6Yb7lW9wO/cCsP9QoWaMQWnmZl" +
                    "TmBtmbBh8wzbhsrM3IfcaUY71slJAR1+WItZrDClm9Q1laqGpT9/xC2G4o3d8/cKJmjF8bjeHd3fqz7hK3z/AA39RgIZH3iZLAVgm04gDVil70ar8REFDNq4+iVEQ50n75iF2sOYow26gAmblFOsRN2QGc6gLzMAdSmQuYt5mLMzQG9QGqZiaIVpU9WJio3LmjPMB4XEI3VXOCFLCkuFnDL2Sndajw4" +
                    "agzT/AK5XBOQ9Kf8AfqCpZy0HfmuJmUaXWd28QSq0ZH+WOwDSrO/6lkU5yPJ/mKgCdCnyfzMy5OsU/wDcxAE1g528x6bqxPlczjVnnVNyshAbO/1/Mu1RFa4lqwUuH8TthnevUanQPVQBAtrm9zNbW+39RGqT34gVbNfqaUn6HMCsQXuBiswfUrnVVK5JzMzfmvU8bj4zUtTjHqbc3FvcrseIilzXqb" +
                    "KUqpYvX/Val8QpzD8xOiLRpGNnXMNAryeGv7gKsaq37v8AcDctMCWd318zJS0Gmx16hZuLVZrPP+1MIVTlwC/zAYsKLox66iZCDYdVmEWwWgh336qAFdKVkMfmMXq2eMyxYG3zHKw5dUbr3cqjQj3th0bXqL8dTTHnfaNAh5gQb36nDXMB1XcPlrE5UkMauBFv4gxRLXXxLZrUHjNR7JfMasfqMaJm" +
                    "O5b1guJzF8d6gs0EVgUPqWghsoVf8ygpYZeax/OpmmhcmRow1vmMJi21dV5+rmUiiF3kp/dzBpwXPGhfzDV2SsN/XUBsNbHLp/MrQKo14lCFabAKV46uVD5wreSBceWhxmv7UhLEGw1CIzrn/bgPiBHCr3KS2+m4/RpOoqhPBcxF5V1d6lnWs9RVcrHmmpgxTAzRUeEfcMmsQF2TfH/sZncrWSUbyz" +
                    "VphOITghhxELE/EKto3mGAzjzL1HW2bNY7zGoDczf8RIdgHVP95h4a6fDT979TJuXBvYgx+JczlhbbZvx3G9gt6DHAbr89RZprgCw68fUVUYsg576/qcCatyo/9iVorSjcAQFBHT4+pWAFoflzM3W8IYEcYbdvXb5zGChelsrDaXaC98fXzLQAVeEWnmOcParI5VCq4SUtqYGtfxFPicR/yFst1Dx/" +
                    "mdAYN4b9QNpWPUogrqocsW4fc2wMKr+pe3ggKgc5qFFcIBiGPF9RDof2QfMNDUhdUaa+SGkJ3gchiMbSweMsfyS4Ao8B5gVUUwpq3nOz9zKBS1nQ/wAeolA2OdP+ZSGADvi383D2BWs25r369Rooi/G7OK1UxGF6q/ctoUwtDP5fxGsYYJd37eY0lELYYT/YiXkNMeJct6W+r/qc01p8RaeKuJV1xAWz" +
                    "Y9a8w43A5qeqG+TDCZtyYlG96hOqwzvYbepf1N1IOpgcMNruCBxccgvtX7hXID+YhDYWtPr8TMBFUWozVH3A6mQ0UO/5iimhfsDD+7z9XKiKCqGQLUvrjw4gDXA2Gq4qXto2nWPFZrXcAQot0Kt8w5RNc8AJ+/uLjSS6qNd89fUrpr57GMQ0UfEsw/3KG7dnO6P7gQCjAAZ1LK1rwrN3CKDG8kvU28ibf" +
                    "B+4KkgWXPXBj8Qd2tnJWurlMlAGsrlF63DlqOmUvNfM1xUBYsusW1LCoMZzqZpaCmvb8S9FRENcsN0yttaF8v6JlfuWq+ITdtwGav6gypfEAcvBHhbliUNLdXrcYILQrv8AB1j/AClhoOeipYoWbtVX+KmHRjHzWMVzEohSxFcu/wCIgiE4Hffz8ZjTKC2Cy6/ubEKYNe0ZOQy3+zqJV2XrNeoEnwqjL/" +
                    "l/cQCYdqAp/EDgHLWyPC/MzNjfJG99l/EBaRktGauyuqq4Ao5oZ4ZVoLWVI6a219+4UrfVG7dy6BrDsvkphDWpdLK81BhDEtpuH1cTojuAYmWT0zwuKI0sUGENaDbnJHcDNNl/DrmU7lTV8LIFBVV+L19TNPC0eJXBALYVfmGGnHHEqOauJ1+JsCX4mnkjVKE80YmkORD/AB/vZYCRemD3UqVZJS0vF6" +
                    "fWYTEO0N4M1u/Ea2AaaV4YFBQcWqZ44vzHQgtgS3OfMBRaCDYDHvCX5lZKmG2l5IXB24DfxEMjsYyUfV35YBuWI4ZuX6hLly7qhuj2/iAwW1zWAt+pnjEA3an8NzFWMFPW1vFa+I0uBF6wXtfH4gjHIgQeQ/mIhXOVLBpTN/7cOacS2lF75+ZkBLgLo/glKANVYdQ0RfcsW3kOT+qlGcfmU88eZkAUIl" +
                    "7+K/mAM2tMEo4dSxaZ2Wzg1pm0rx4iDWBKM0yZ/MuWPwXszv8A5BCw0bls9OqZ5pjxW6nAwqhkhZYrpdxV/Tmi7rmNoDtAod+Y0etSla51wdxrN27xUSdlxt+bXuUVXNub93/vUQqmxih8+BgzDo0Wvt4+fmOhBbaLwPLojTx7FwP7fxG75aWGjZ5rn53ADkC/4/UST7NvRWPxqLEkkNZVv0RFbFtoTJ" +
                    "xlgXEUX2ri9l+IokSrxb9rObQyDgdIdY8xUcwurF17hzZMcDfvMcqJQ2KuazfP0xBCJdc/uXMu7ogNSSJyf4ii4Yl6YqKT8IkVpkJu3zczbvAmHozUuRVCBdKWn6GWy/EaieDjzAgAMJkFrqufuGHt0UtrPErBCs7/AJcxuc/xArFT19Sr+YnG+OIgNpOK/wC+JXtgwGLvj/v+WuiVKvBzfZgJaq0bVP" +
                    "y0yqWSoBQ/Qdd/sCmIpiePfzVMdA1bG0PjvuJCOBYa0YDN1BgrUeA2eML4jcq3VD9NuuKjZZVjKOqeP1LiZZM88Lg3XTxA1UtHAqzbZ/PiGSopVLDNfpMb8R5y3IZoCt6JQcWkWLqytP3LQJlxjy9xhuclAFxni9+o845CwSsYt1XiOuC7ffJxv1LdmqycdDEK63GspvnMuW2heZUtQgK7f3AWuZjEow" +
                    "Fr9+P1LEiqBvjffNwHWysNnOfFRSIHZGB+ZZramV5POcQFRatrfTWA+ZkKvNmX/dQ1NoE4fwS/WG6sbyeY1Zpit7hXm7IGcw2wlNh9wCxVNYeAlRZx+Nm+YhaSwU0u1DGsq/1EBOzyt6L4iqxhbuougSKdAtxgXuv5upUQgoJV8+6yHm3MqQrabyyqe7q39S8EoLZNtdXcAOV51efpPm48OizRr53Wcu" +
                    "JTgSioaq2r7lbQWpdunvd/RfeYncdXY8c/zcCHV7rDVHF6xqtx2rALnXIGBrrUWKTwMr1ZrdZ6mANumSr0FAfXzLKKlWqWb9J41UwZSl5dBxUulMlw2OPcWG09y8A5gL1Gr3n9xNA3A8KtCXcHkjDcB81zAi7GSuS8PmwuOIEHEXzxpvn9wEmfaxq1c/EAiXbivrjcPV9qP4YzCCdnIWT/AL9srZxLwP" +
                    "gf+S1AmPcYUaaXXZBgim8NJw+ZZeGjG0O5X7RZ1aeeYhEs5LN5YeMDnZ9u/iLBS0x1lj7gdoV9sh54LWW1hXZlafyxwlDzrO6zj4mw6rSra1jcMqRSW88baCFRJZbxb18QIgXa50G/NrFiIF3td49+NwAjq2r1seb8VcY6oC5wW0Xt5Xj6hWZjaBB3XH+ruGgOAEOeXWPHxu4/LI0UegMb+pZAvnTl8" +
                    "57xCQVhw1ReufHMx4AQY+E746iJs0xqfZG5URWaCuY8hDocdF7ZQQjRaN1xULHFZRr29xAs1e2OSx5V5nholf45JvyXU5tqzu8X+oUcOZXnK8+4UBUlCizo6+MR7Yt26+fruNatZxPvQwhV1L2efg/1xqCpVLdfR6gKjoIJkzlw+fUDk1syM0PF0wtVuDxbz5rZMF0IoQ79ywMU/DXe54/BQ3+YY273" +
                    "2+OPzAvenbX0wbBou7qoF0KgWLxmqx45ILMksORoNG8v/syUp8gH5597zA7inpLePG/iPUiousOF/F/Mam+mgxrFvH8sHCpVJYAve8MEMUkoQBDy25edQluiqFqvONtYtui63KUMWrCx1d+61LABTThh4aymnsdSzsKlVMCrvv8AuMjgujJc2cDTzDvKy0AmPF3CVIAqyutdP2xZeIq6U96fuITdrMcPW" +
                    "4FS5KbyHv1HVgprBfi4ltFyJ++/mOZOsU39RTLsbogc7AwDw80QEapg3tnxjUClVp7ZYoaC40jWylrzjoPGZdTaqUbergW/kXP1x+azA53BWmSr7/zxF5BTFuoyRxrULDZXvUZBCaNAfsvzEtGRPO8dXr4zCMWkFl5QyHx8R9ODYMry6hRhvl/cFXGArbfC8QYBLoKZ8VuVWQA6k3ayhp39QYG0YKo5X" +
                    "7nLl30bXNZr0X3E9KeIoZCv9+IsFJFTZE0Z5iw6Aunf9bluwLQRXCavHVMxOur7cve8Vs5MyzDbaitqGXsvfUGVVVZsacBno+c2xOsFAoTDeq+kruIPBVVAXW6oKqXFdDwAM0HExeBQAlrfxi6l5VXjG/hTJ4u42oUq6Pss/mEqJoKm/Wa+4qQDFjdv8PioElWAEFz+oU00qqoUZ+awYlUCyG1Lz+Yi" +
                    "pkwr8kKSBxkxFZhyfHkIwJi0LD6uo+sRyWbcnHK9QUMkTCnyu5jy24F4fnjES9I2gvX4gO4AZC77r3rx7lkWau9+mAGRRxOEVCr75+o1Yp4pUAN3TtVHMKqNCTkpprWEzEOUaAPusQKqhXCUcmYSLSZABc1zmDLDk1ZcEi8BnN5/nM3ecaABrFUHxAmGa9HTJelHU0QCMtX/AMvqG87BWzV2ZcGv5oO" +
                    "QczY31VRyrW6nTjis1v8ANR0JqrGipYxnnxAESqGTI0Y14uK/4iEENdayxp664gUDrG88faCnJTAmx1Ww50udJAWyp1WgHyWsFwNHrTZ+cf4j2G4ch5p5Dp4mqpk5K4rv7jiiM0Py9cyiIqzPdSlZndZ8/UtF1MYrfuHKNFvl7hBQ2stQHx4lRFIzdwd+H/EsvqaZJ66m2dUHQZvHnMAqAVSIQ6Ofevc" +
                    "fGist1X4SCsLBRUlWVmIN2AUYz8jCAXKJYPL38xNaj2v8w03DPv3GiCqrJfzCgaFRZP7/AHMnIgVgbsvNRlW3bFa8NZwZhjIysoocN/u4qi0gA0i0vUMOqgi07axdG4LzCu84/uCrIgipgfEVdOsILN8Xk8hDtxTHovnmu+WAEIVXRVNXebxfg/KMcpSuVwvDxHfw51Q65rBW2WaXDVZft19YmOhAlQt" +
                    "dThUrejNgbi/YYnEMlKWYmoDCwEsejxwzIMOyhXuwE2748zMFAY3St/QJAe1I7YU/DeIlhBhsMwb8Hvi4qtGaQqzr+4IF1jL+7lLC26AueunfEE58NzrhNkqpVathhuuiHBbI4D1xUyBto2q3USlAtaLfTzHKs0MM336gRGM4ub98StQAmzgeP1DQTIUMG7fP4nNxN388f7cdCEgJsfDu5UQhSI+nhzGo" +
                    "Tlk8cTlH9n/YipWmA17IkMI5BZ99xuSjtrwPEB1pPIFlvI4YK0I9lpRfyYjxpOFYA29WnmVuRCKaXty7RuSAovZ4XfzUN0ImDdZgmasDi3/uVOjXBun/AIh6LdaLeWX9OsqAHBpcXVawYAcpy5fxBvUA6KTVHTy5hu4wgXi1gceM4r5mI3CSobLRtC+zgsS4yt2wHkse6sNQogIDa7ov9JvGMR32LMK2" +
                    "VY8Pla61MF4EWl0a9TfMaDVo/wDcxCEVQDv9MbBa89fEMkEONPk9yg9UoBX5xMJbqN5LhiCA8cncODpwt/mBM1sGDX8XKIoDkL+oiKsVR71eo00DNNd/fxCoSIqQDd6MuY9tu1mvCYuFTIFSNi6r3DgbCFtjpP8AyHWPXpTs+oV2fVXN4zBxbwZSDrYbT+0UcRYBGQPPkyiykBx1i/1HKoUNTv37gS/K" +
                    "dTZfl85xAI1spNWePfqO0gQRRnXfVal+RxMopydkKeRsKvdiDNx3sgi2C7rsJlAYD1e/uqxkzkzEcdcCYrg+fq2IIFzkFA7KxT+IneYCGlo6w1iyAKVe0KDNc6IuTpVXOButmb9fUdbBpdt2b9bYAO0shr0HLvEzbCU4jq+9eJcxVGVIYsd9e4yptDej9n/ZUYQtEtOviY4qc3vz5mWinkZy1wUq05u9Q" +
                    "M2OLeHUtgcWqbxzKK2ywvnqMAyc1VMAcNH2L/mMdt1u74nDxAL8KZqY0HMDFvcomJymA4PgZSSZwFY+PeooFcVgNXk6dxJQEa2QTf4JmYVXJNAw1oYxpGQwKpwH1csJ6susVa7zjMYKIX0N0tdxQC5SHHi/jiDqqG4NULvqm35h9prW6rCeJQlla+f/AIWheTm2XoV2eTnJdeMeSDd1UsrY5XV9HBEWjE" +
                    "QwDAvnOc+YRaCAqjJHOSnxl43Hj4sL16/HUPpqDBfj1X3HtC5xvxv/ANgFhclWPLMX/aVxec1z1EDTWyUGCnH8y/QXkrTkv4z/AK4NpbZy4QpRcaunXHcAzwUs/wB8wakGcsxFIF1Xp/khSqos7liiwutmMmr1Tf3BxJmnvER1yV8lxyCq1fUd7QHs7CauH8V19y8Q9VA4HwuUbwQ1/wCRuFiVsllEGV" +
                    "q8/EoLLEyg7+ZQ5G/G8XH0wsAREvBFUKXUwwUpyef6ibW82/cSfpk/UUU/ajvyBD6Ovjf58Ru0tmKoVdnhR+IyS2wNisdGyoUZkxNluVdYq/EeOAb3iLKbYqV6D+ZR2xFYe3INy41dWKpblozzW4ZDVKJWS889wNtgZZycxbWCmGRc5+54zJFqzX3HqljC2nPqqYUAMdJ85iCq14KZbArbg/jEIdgySn" +
                    "8woUHnDf6lSC7XmFZcu+lgB5Wv5gM7t/FxMQAgHxqWCT9TdaqUXr1ElidsDGcnuJBywQp2QqRSWJgFxuvfErAKKzdwer/MsYsT0kzWP1BJgFl4Xneqiiiu05jWAmd7lQsHqLg6+lf1CCEVwVl8fURYglaeluKiIFlWc18qEaLxaQVt4+/MsIJg5o5H5z6lWGrpYG8fvusyuyCiY4FXq7zetcwsXPOHPS" +
                    "7/AHAX61/3iSSxN1abZz1m7D/6Yjh3yg8ysK8WKa4vxhuGsHNikemVk7gyTn61KKht9TQ/7+ZeAsUmjb/yHYbw45gKRyJnpmRN5sCwC7r1mO9CovxMYDQH3KjFVVOVN/MSRklHQuTqDLjPuZiIPzD2UMqHWJSiUN3Qcfn7lDMCeqhBbY9RWD7quWtlvkH8S0XztG/1BimO7ax8xApDsV718ZhS9CzPqA" +
                    "om6sflhYUTT7eG41VWA4Xxj2jwgab4/iMcL9lX9BS9uuobT0DAbFufZcSq3NduhNDur46/LbU/UCnCF+4YikyrXjtVRDbZdBV58eIyktDXUBpDAHi9+4xTV8vK3efE55TniHY9GDXtv9QJkFzx2wC2P0TjPHqdlo/uGQsoHzUfEUD+IxKy8YbYKeSRQNWMDzCoIzgs3AlTEbmiClrmGVw+IQRPv/kbk93" +
                    "KNXRTMG2Rx5uDsvdNfqJHdM2PkSKgAc9wKgr7jcWD9I5VB3eYG3l6cyy2vtlxMPWYSZw+S0Uvj5Y5q27YtJZnES9KTwjd+uJm2k+ogrTCBwoibnRaF+odtL+o8l1iBSiD3K6VfPmGWaSytV5ZSyc+Y0qn/EoRCh8IJBsbiNm27/iEZqx+o+1m/wAwGuwP3KkRUp6uVYUGgq5uZrkXGqiklhxXDANKYC4r" +
                    "9xvFSwxbMDKvHsJo6fP6gYtrpS48D9yWZLfuU3aSWlX88RT9yAYLcRe9wafC2PJ/UyIymUfUIg2s+cV/E4D/ABC6b3Myve46ZG3MSUL44iGxMdzGbI0rxkzzKco3uW1h0xUxcCa9RkS6N55llaUhBFlq9wDQU1AALrSPT5ke6Zcm6I9+4oC1j7XLhLDJiL2hVqsGL88xEga4rEQV4tDXH1MaLxzATeZh" +
                    "bvmFVCyPtHkWalKPBLgU/IM+yYKhOKjyxx3EDcFEDEUhcq6KX+JauIbX8Qwyn3CVlYFfMQWAV6lXCMZanlAARboJ0h5i2BoNmJYICDwTE+eYpQCoxRzqKzTiqg0ihgkN3A0jzBxUC0C2fhhtYVPmBHpsfcqFcw2+TyL/ALl2pV48xQYcnNEMUUqlY6W9RICp3LkkL4nAgRZdwKqr8SkB5gNjmIzREWpz" +
                    "KQiXt82RiiX1NWyzjE2Y+kAkb/UpTbEMyY3BBy+o7DcRQUANTEHTHK7RhS9C3EsjIUBsZTiZRW0Fr4IyDxPyqhEAdJi6QV2/4nAZ/JLKzYxb7IjTeH6RUCWtemKQKH5JiZen9xMvpv3LCac/W99RiqGicATuoopU6ajsJecTHj8ITAY3iB32q5lDKj/RKYtFe8P0wADDTfmahpynMKOFeoMvse6iJfq4" +
                    "dGMlZ5iSqxfuZY18QGHipkC5Q3Q3LWUI0XakeIUIKQ7EpWYBRrcdOGxlrXiPU4H/AODioRm4LmwbB+4zj3ZmIiin1OTzb+6mGuwHzCvhS8a1Ks7N/cKo5p7rMYii73xKQGB0xEjn4ukjgI3M8TGG4oxpbaeJgQVWtvcDV1qBYU1DqC70dwZkNLMlTPMCoFjCCCU78zSEBSqJjNyW/wAy1iPeIa7tVnEQ" +
                    "V5/BRFxuGtXSpe77lk6pgzku5lORXWWJXMyF8TBfX/yncWq4ie0kMM2DEC0Xo49xzLflO4DtMMY8Rzep/ca28AfiEHMI91CIZUTPk3v6cRxaW4LeIVDLT+oi26r9Im4t0SWHZvPmCA1ZiOFwOYuRKpd99wAIqjmOQUEx7lyCmh7qKbZoI7M1YDdXUpA7r+5YWqTEvKtIfbFKqiD0BYsv8TzYGUB7/glN" +
                    "mVGy0V9SqFszjmcdA/c5Ze/MwuEJjVJR5myBheJyu6lY7AvzMJALc9RJXu5Mk6oLxxEtmUYxq0l3zZGGRX9dSqNrJXMdvLKw5LjmHbH1CIeDRQgNl5hu0Tetw0jdxtIrXvcynoGThviGScAMQkdmH5lrFCkJ1xLH5gLEChrfmAF3DyLgP7hQCgV03GuJB+XiJQp5jOSgJXZw/UusMxXRaBS8kBndmBR3L" +
                    "RVM4V/X/wAJpjuVF4MyOdErU7siEKVmBN7Q2kzgMC8WWxKECUA6xPOEp4IC1lz8P6nMNmZbkKXFFHPeVdPRB9Am7YHCOrXgikgQa8QlGgAHzFYcCElFWtfMN+llXyCZUXcuT1CwJBNeWYisOPMPEPrLGbYx2m9Q+pvpGjX0iWuWFESLyYRiYFRn/9k=",
                    Term_of_Receipt = DateTime.Now, // год - месяц - день - час - минута - секунда
                    AccountID = new Guid("DF52BCA9-3E33-489E-8CE5-CD665C163589")
                }
            };
        }

        private static IEnumerable<ProductInImageConfiguration> GetPreconfiguredProductsInImages()
        {
            return new List<ProductInImageConfiguration>()
            {
                new ProductInImageConfiguration()
                {
                    ImageID = new Guid("6b62cd34-56b3-4e94-9ab6-ae9d00b3e3e9"),
                    ProductID = new Guid("730b2a39-cb74-4eb0-ab90-43de3970caae"),
                    Probability_recognition = 64.3
                },
                new ProductInImageConfiguration()
                {
                    ImageID = new Guid("6b62cd34-56b3-4e94-9ab6-ae9d00b3e3e9"),
                    ProductID = new Guid("f35200f7-bd6c-4110-b3d3-72f6378634a8"),
                    Probability_recognition = 87.1
                },
                new ProductInImageConfiguration()
                {
                    ImageID = new Guid("78207739-bbd2-4e05-a2a5-ae9d00b3e3e9"),
                    ProductID = new Guid("4eea67a3-9b8c-47a5-b19c-5dac727d7cab"),
                    Probability_recognition = 14.9
                }
            };
        }

        private static IEnumerable<ProductConfiguration> GetPreconfiguredProducts()
        {
            return new List<ProductConfiguration>()
            {
                new ProductConfiguration()
                {
                    Product_ID = new Guid("730b2a39-cb74-4eb0-ab90-43de3970caae"),
                    Name = "Сывороточный напиток. Мажитэль ананас манго"
                },
                new ProductConfiguration()
                {
                    Product_ID = new Guid("f35200f7-bd6c-4110-b3d3-72f6378634a8"),
                    Name = "Йогурт. Активиа чернослив"
                },
                new ProductConfiguration()
                {
                    Product_ID = new Guid("4eea67a3-9b8c-47a5-b19c-5dac727d7cab"),
                    Name = "Йогурт. Активиа киви и мюсли"
                }
            };
        }

        private static IEnumerable<ProductFrameConfiguration> GetPreconfiguredProductsFrames()
        {
            return new List<ProductFrameConfiguration>()
            {
                new ProductFrameConfiguration()
                {
                    Top_Left_Corner_Coord_X = 165,
                    Top_Left_Corner_Coord_Y = 2780,
                    Frame_Height = 452,
                    Frame_Width = 352,
                    ProductInImageID = new Guid("a159283a-e0d1-4c32-90e5-c879534b394c"),
                },
                new ProductFrameConfiguration()
                {
                    Top_Left_Corner_Coord_X = 974,
                    Top_Left_Corner_Coord_Y =  363,
                    Frame_Height = 789,
                    Frame_Width = 43,
                    ProductInImageID = new Guid("e81c5943-21ad-4d4b-931e-766a0ac626a7"),
                },
                new ProductFrameConfiguration()
                {
                    Top_Left_Corner_Coord_X = 95,
                    Top_Left_Corner_Coord_Y = 356,
                    Frame_Height = 467,
                    Frame_Width = 642,
                    ProductInImageID = new Guid("cea66ef0-e1a8-46ca-b6c1-c4ec4b9a4ad1"),
                }
            };
        }

    }
}
