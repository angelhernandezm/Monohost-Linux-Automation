#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <memory>
#include <algorithm>
#include <string>
#include "monowrapper.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    ~MainWindow();
    explicit MainWindow(QWidget *parent = 0);
    static void LogMessage(const char *msg);

private slots:
    void on_btnStartHost_clicked();

    void on_btnExitHost_clicked();

private:
    Ui::MainWindow *ui;
    std::unique_ptr<monowrapper> m_monoWrapper;
};

#endif // MAINWINDOW_H
