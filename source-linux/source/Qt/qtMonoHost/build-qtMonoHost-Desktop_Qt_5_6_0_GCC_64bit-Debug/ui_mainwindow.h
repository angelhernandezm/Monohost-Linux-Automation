/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.6.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QPushButton *btnStartHost;
    QListWidget *lstMessages;
    QLabel *lblMessages;
    QPushButton *btnExitHost;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->resize(555, 313);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        btnStartHost = new QPushButton(centralWidget);
        btnStartHost->setObjectName(QStringLiteral("btnStartHost"));
        btnStartHost->setGeometry(QRect(200, 220, 151, 27));
        lstMessages = new QListWidget(centralWidget);
        lstMessages->setObjectName(QStringLiteral("lstMessages"));
        lstMessages->setGeometry(QRect(20, 30, 511, 181));
        lblMessages = new QLabel(centralWidget);
        lblMessages->setObjectName(QStringLiteral("lblMessages"));
        lblMessages->setGeometry(QRect(20, 10, 67, 17));
        btnExitHost = new QPushButton(centralWidget);
        btnExitHost->setObjectName(QStringLiteral("btnExitHost"));
        btnExitHost->setGeometry(QRect(380, 220, 151, 27));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 555, 25));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        MainWindow->setStatusBar(statusBar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "WCF Host built with Qt", 0));
        btnStartHost->setText(QApplication::translate("MainWindow", "&Start WCF Host", 0));
        lblMessages->setText(QApplication::translate("MainWindow", "Messages", 0));
        btnExitHost->setText(QApplication::translate("MainWindow", "&Exit Host", 0));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
