namespace FsharpSampleProj1

module Say =

    open FSharp.Data;
    type FinanceData = HtmlProvider<"https://finance.yahoo.com/quote/^GSPC/history?p=^GSPC">
    type dateWiseHiLow = {date: string; openingValue: string;High: string;Low:string; close: string;volume: string }
    let table = FinanceData.Load("https://finance.yahoo.com/quote/^GSPC/history?p=^GSPC")
                        .Tables
                        .Table1
                      
    let  rows = table.Rows
                |> Seq.map(fun r->{ date = r.``Date``;
                                    openingValue = r.Open;
                                    High= r.``High``;
                                    Low=r.Low;
                                    close=r.``Close*``;
                                    volume=r.Volume
                                    })
                |> Seq.toList
    

