Imports System.Runtime.InteropServices

Public Class Monitor_Class

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MONITORPOWER As Integer = &HF170
    Private Const HWND_BROADCAST As Integer = &HFFFF
    Private Const INPUT_MOUSE As Integer = 0
    Private Const MOUSEEVENTF_MOVE As Integer = &H1


    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SendInput(<[In]()> ByVal nInput As UInt32, <[In](), MarshalAs(UnmanagedType.LPArray, ArraySubType:=UnmanagedType.Struct, SizeParamIndex:=0)> ByVal pInputs() As INPUT, <[In]()> ByVal cbInput As Int32) As UInt32
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Sub mouse_event(dwFlags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As Integer)
    End Sub

    Public Shared Sub Turn_On()

        mouse_event(MOUSEEVENTF_MOVE, 0, 1, 0, UIntPtr.Zero)
    End Sub


    Private Structure INPUT
        Public type As Integer
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure



    Public Shared Sub Enable()
        Dim inputs As New INPUT()

        inputs.type = INPUT_MOUSE
        inputs.dx = 1
        inputs.dy = 0
        inputs.mouseData = 0
        inputs.dwFlags = MOUSEEVENTF_MOVE
        inputs.time = 0
        inputs.dwExtraInfo = IntPtr.Zero

        SendInput(1, {inputs}, 28)
    End Sub
End Class
