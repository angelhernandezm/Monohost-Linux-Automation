#ifndef MONOWRAPPER_H
#define MONOWRAPPER_H

#include <functional>
#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/mono-config.h>

class monowrapper
{
public:
    monowrapper();
    void UnloadAppDomain();
    void CreateDomain(std::function<void(const char*)> logger);

protected:
    bool Initialized_get() const;
    std::function<void(const char*)> m_logger;

private:
    MonoDomain* m_domain;
    MonoImage* m_monoImage;
    MonoClass* m_hostClass;
    MonoAssembly *m_assembly;
    MonoObject* m_hostInstance;
    bool m_IsInitialized = false;
};

#endif // MONOWRAPPER_H
