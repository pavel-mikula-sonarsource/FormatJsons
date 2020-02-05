
Imports System.IO

Module MainMod

    Sub Main(ParamArray Args() As String)
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
        For Each DN As String In Directory.GetDirectories(Root)
            Process(DN)
        Next
        For Each FN As String In Directory.GetFiles(Root, "*.json")

        Next
    End Sub

End Module
