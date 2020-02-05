
Imports System.IO
Imports System.Text.Json

Module Program

    Sub Main(Args As String())
        Try
            For Each Arg As String In Args
                If Directory.Exists(Arg) Then
                    Console.WriteLine("Processing: " & Arg)
                    Process(Arg)
                Else
                    Console.WriteLine("Directory not found: " & Arg)
                End If
            Next
            Console.WriteLine("Done")
        Catch ex As Exception
            Console.WriteLine($"ERROR {ex.GetType.ToString}: {ex.Message}")
            Console.WriteLine()
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub Process(Root As String)
        Dim jDoc As JsonDocument, aSdf As String
        For Each DN As String In Directory.GetDirectories(Root)
            Process(DN)
        Next
        For Each FN As String In Directory.GetFiles(Root, "*.json")
            aSdf = File.ReadAllText(FN)
            aSdf = aSdf.Replace("'", """")
            jDoc = JsonDocument.Parse(aSdf, New JsonDocumentOptions With {.AllowTrailingCommas = True})
            Using fs As New FileStream(FN, FileMode.Open), wr As New Utf8JsonWriter(fs, New JsonWriterOptions With {.Indented = True})
                jDoc.WriteTo(wr)
            End Using
        Next
    End Sub

End Module
