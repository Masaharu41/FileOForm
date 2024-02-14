



Option Explicit On
Option Strict On
Imports System.Collections.Specialized
Imports System.Security.Cryptography

Module FileOForm

    Sub Main()
        'ReadFromFile()
        '   WriteAsAppend()
        'WriteAsOutput()
        'For i = 0 To 254
        '    Console.WriteLine($"{i}: {ChrW(i)}")
        'Next
        ReadCustomerData()
        Console.Read()
    End Sub

    Sub WriteAsOutput()
        'Open with Output creates a new file each time and overwrites the existing of the same name

        FileOpen(1, "TextFile.txt", OpenMode.Output)
        For i = 1 To 5
            Write(1, "Hello File")
        Next
        FileClose(1)
    End Sub

    Sub WriteAsAppend()
        'Open with Append writes the text to the file but will write this after what is currently stored in the file
        'This will also create a new file if needed. PREFERRED OpenMode
        Dim appendedRecord As String
        FileOpen(1, "..\..\AppendMe.txt", OpenMode.Append)

        Write(1, "Follow the white rabbit...")

        FileClose(1)

        FileOpen(1, "AppendMe.txt", OpenMode.Input)
        Do Until EOF(1)
            'reads each line until the end of the file is detected
            Input(1, appendedRecord)

            Console.WriteLine(appendedRecord)
        Loop
        FileClose(1)
    End Sub

    Sub ReadFromFile()
        'Writes new File every time the program is run. will overwrite all past data
        FileOpen(1, "ShinyNewFile.txt", OpenMode.Output)

        Write(1, "Oye Mate")
        FileClose(1)
        Dim currentRecord$
        'Reads the file that was created and intakes the data and writes it to the variable
        Try
            FileOpen(1, "ShinyNewFile.txt", OpenMode.Input)

            Input(1, currentRecord)

            Console.WriteLine(currentRecord)

            FileClose(1)

        Catch ex As Exception
            Console.WriteLine(ex.StackTrace.ToString())

        End Try

    End Sub

    Sub ReadCustomerData()
        Dim recordData$, firstName$, lastName$, city$, email$
        Dim temp() As String

        Try
            FileOpen(1, "UserData.txt", OpenMode.Input)
            Do Until EOF(1)

                recordData = LineInput(1)

                temp = Split(recordData, ",")

                firstName = temp(0)
                lastName = temp(1)
                city = temp(2)
                email = temp(3)

                temp = Split(firstName, "$$")
                firstName = temp(1)
                email = Replace(email, Chr(34), "")
                email = Replace(email, Chr(160), "")
                email = Replace(email, Chr(194), "")
                lastName = Replace(lastName, Chr(194), "")

                Console.WriteLine($"First name: {firstName}")
                Console.WriteLine($"Last name: {lastName}")
                Console.WriteLine($"city: {city}")
                Console.WriteLine($"email: {email}")
                Console.ReadLine()

            Loop

            FileClose(1)
        Catch ex As Exception
            FileClose(1)
        End Try
    End Sub
End Module
