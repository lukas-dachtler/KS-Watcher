Imports NAudio.Wave

Public Class LoopStream
    Inherits WaveStream
    Private ReadOnly source_stream As WaveStream

    ''' <summary>
    ''' Creates a new LoopStream.
    ''' </summary>
    ''' <param name="source_stream">stream to read from. (Note: the Read method of this stream should return 0 when it reaches the end
    ''' or else it will not loop to the start again.)</param>
    Public Sub New(source_stream As WaveStream)
        Me.source_stream = source_stream
        EnableLooping = True
    End Sub

    Public Property EnableLooping As Boolean

    Public Overrides ReadOnly Property WaveFormat As WaveFormat
        Get
            Return source_stream.WaveFormat
        End Get
    End Property

    Public Overrides ReadOnly Property Length As Long
        Get
            Return source_stream.Length
        End Get
    End Property

    Public Overrides Property Position As Long
        Get
            Return source_stream.Position
        End Get
        Set
            source_stream.Position = Value
        End Set
    End Property

    Public Overrides Function Read(buffer As Byte(), offset As Integer, count As Integer) As Integer
        Dim total_bytes = 0
        While total_bytes < count
            Dim bytes As Integer = source_stream.Read(buffer, offset + total_bytes, count - total_bytes)
            If bytes = 0 Then
                If source_stream.Position = 0 OrElse Not EnableLooping Then
                    Exit While
                End If
                source_stream.Position = 0
            End If
            total_bytes += bytes
        End While
        Return total_bytes
    End Function
End Class