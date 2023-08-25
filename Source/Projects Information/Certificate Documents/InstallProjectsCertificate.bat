@rem Install all *.pfx files to certmgr.exe before run this batch file.
@rem Run this batch file in 'Developer Command Prompt for VS2012' (Run as administrator).

sn -d VS_KEY_7BE3079DC63BAA80
sn -d VS_KEY_BF969362A61B9A23
sn -d VS_KEY_5C0BC820D9CEBCDA
sn -d VS_KEY_5CFA97F02E893271
sn -d VS_KEY_E8348F0D38BE5C2C
sn -d VS_KEY_CDC067FA3E6CCAFE
sn -d VS_KEY_54B763EA3EA9555A
sn -d VS_KEY_35CB79515C487D20
sn -d VS_KEY_882752D6E475F4B7
sn -d VS_KEY_101650B6E6C64C39
sn -d VS_KEY_5FE9D836F94AB213
sn -d VS_KEY_0EEF62E4CD5DA950
sn -d VS_KEY_40AAA4C9279D593A
sn -d VS_KEY_B1ABAEA5E9D5C3DA
sn -d VS_KEY_EA75DB8A1C503654
sn -d VS_KEY_A10F3BCB9D7D6195
sn -d VS_KEY_3109A5CBE4119658
sn -d VS_KEY_E832C2D476CD1B9A
sn -d VS_KEY_89212F609D3B33A9
sn -d VS_KEY_B104630709354B56

sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Basis\ApaGroup.Framework.Basis.pfx VS_KEY_7BE3079DC63BAA80
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Bol\ApaGroup.Framework.Bol.pfx VS_KEY_BF969362A61B9A23
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Dal.Context\ApaGroup.Framework.Dal.Context.pfx VS_KEY_5C0BC820D9CEBCDA
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Dal.DataStructure\ApaGroup.Framework.Dal.DataStructure.pfx VS_KEY_5CFA97F02E893271
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Factory\ApaGroup.Framework.Factory.pfx VS_KEY_E8348F0D38BE5C2C
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.IBol\ApaGroup.Framework.IBol.pfx VS_KEY_CDC067FA3E6CCAFE
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Identification\ApaGroup.Framework.Identification.pfx VS_KEY_54B763EA3EA9555A
sn -i ..\..\ApaGroup.Framework\ApaGroup.Framework.Shared\ApaGroup.Framework.Shared.pfx VS_KEY_35CB79515C487D20
sn -i ..\..\ApaGroup.ApaService\ApaService.Framework\ApaService.Framework.Bol\ApaService.Framework.Bol.pfx VS_KEY_882752D6E475F4B7
sn -i ..\..\ApaGroup.ApaService\ApaService.Framework\ApaService.Framework.Dal.Context\ApaService.Framework.Dal.Context.pfx VS_KEY_101650B6E6C64C39
sn -i ..\..\ApaGroup.ApaService\ApaService.Framework\ApaService.Framework.Dal.DataStructure\ApaService.Framework.Dal.DataStructure.pfx VS_KEY_5FE9D836F94AB213
sn -i ..\..\ApaGroup.ApaService\ApaService.Framework\ApaService.Framework.Factory\ApaService.Framework.Factory.pfx VS_KEY_0EEF62E4CD5DA950
sn -i ..\..\ApaGroup.ApaService\ApaService.Framework\ApaService.Framework.IBol\ApaService.Framework.IBol.pfx VS_KEY_40AAA4C9279D593A
sn -i ..\..\ApaGroup.ApaService\ApaService.Framework\ApaService.Framework.Shared\ApaService.Framework.Shared.pfx VS_KEY_B1ABAEA5E9D5C3DA
sn -i ..\..\ApaGroup.ApaService\ApaService.Comminucation\ApaService.Comminucation.Bol\ApaService.Comminucation.Bol.pfx VS_KEY_EA75DB8A1C503654
sn -i ..\..\ApaGroup.ApaService\ApaService.Comminucation\ApaService.Comminucation.Proxy.Web\ApaService.Comminucation.Proxy.Web.pfx VS_KEY_A10F3BCB9D7D6195
sn -i ..\..\ApaGroup.ApaService\ApaService.Comminucation\ApaService.Comminucation.Proxy.Win\ApaService.Comminucation.Proxy.Win.pfx VS_KEY_3109A5CBE4119658
sn -i ..\..\ApaGroup.ApaService\ApaService.Comminucation\ApaService.Comminucation.Security\ApaService.Comminucation.Security.pfx VS_KEY_E832C2D476CD1B9A
sn -i ..\..\ApaGroup.ApaService\ApaService.Comminucation\ApaService.Comminucation.Service.Web\ApaService.Comminucation.Service.Web.pfx VS_KEY_89212F609D3B33A9
sn -i ..\..\ApaGroup.ApaService\ApaService.Comminucation\ApaService.Comminucation.Service.Win\ApaService.Comminucation.Service.Win.pfx VS_KEY_B104630709354B56