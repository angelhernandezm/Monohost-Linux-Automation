#include "monowrapper.h"

monowrapper::monowrapper() {

}

bool monowrapper::Initialized_get() const {
    return m_IsInitialized;
}

void monowrapper::UnloadAppDomain() {
    if (m_IsInitialized)
        mono_jit_cleanup(m_domain);
}

void monowrapper::CreateDomain(std::function<void(const char*)> logger) {
    if (m_IsInitialized)
        return;

    m_logger = logger;

    mono_set_dirs("/usr/lib/", "/etc/mono");

    mono_config_parse(nullptr);

    m_domain = mono_jit_init("./MonoDaemon.Service.dll");

    m_assembly = mono_domain_assembly_open (m_domain, "./MonoDaemon.ServiceHost.dll");

    if (m_assembly) {
        MonoObject* ex = nullptr;
        mono_domain_set_config(m_domain, "/etc/mono/4.5/", "machine.config");
        m_monoImage = mono_assembly_get_image(m_assembly);
        m_hostClass = mono_class_from_name(m_monoImage, "MonoDaemon", "ServiceHost");
        m_hostInstance  = mono_object_new(m_domain, m_hostClass);
        auto ctorMethod = mono_class_get_method_from_name(m_hostClass, ".ctor", 0);
        mono_runtime_invoke(ctorMethod, m_hostClass, nullptr, &ex);
        auto hostInitializeMethod = mono_class_get_method_from_name(m_hostClass, "InitializeHost", 1);
        void* args[1] = {&logger};
        mono_runtime_invoke(hostInitializeMethod, m_hostInstance, args, &ex);
        m_IsInitialized = true;
    } else {
        // Log & display error message here

    }
}
