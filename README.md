# ThreeButtons
This project is a Windows Form Application that contain 3 buttons that have following requirements.

1. On close (WM_CLOSE) should hide (remove from Taskbar) the main Form, but not terminate the current process
2. Add a button to terminate application
3. Add a second button to start/run a new instance of this application
4. Add a third button to terminate all running instances 
5. If any instance of application is still running, the next execution (e.g., start form file explorer or command prompt) should only restore the main form of any running instance and/or bring it to the top of Z-order


