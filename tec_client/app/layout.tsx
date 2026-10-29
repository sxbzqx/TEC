import type { Metadata } from "next";
import { cookies } from "next/headers";
import { AntdRegistry } from "@ant-design/nextjs-registry";
import Providers from "./providers";
import Sidebar from "@/components/navbar/Sidebar";
import FooterWrapper from "@/components/navbar/Footer";
import { App, Layout } from "antd";
import { Content } from "antd/es/layout/layout";
import { AuthProvider } from "@/context/AuthContext";
import { RealtimeProvider } from "@/context/RealtimeContext";
import { decodeAccessToken } from "@/utils/jwt";
import "./globals.css";
// import ContextMenuWrapper from "@/components/contextMenu/contextMenuWrapper";кастом пкм

export const metadata: Metadata = {
  icons: { icon: "/factory-32.png" },
  title: "Корпоративный сайт ТЭЦ",
  description: "Система управления ТЭЦ г. Бишкек",
};

export default async function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const cookieStore = await cookies();
  const { role, loginName } = decodeAccessToken(
    cookieStore.get("accessToken")?.value,
  );

  const initialAuth = {
    role: role || "Guest",
    loginName: loginName || "",
  };

  const initialTheme = cookieStore.get("theme")?.value === "dark" ? "dark" : "light";
  const initialLocale = cookieStore.get("locale")?.value === "kg" ? "kg" : "ru";

  return (
    <html
      lang={initialLocale === "kg" ? "ky" : "ru"}
      data-theme={initialTheme}
    >
      <body>
        <AntdRegistry>
          <Providers initialTheme={initialTheme} initialLocale={initialLocale}>
            <AuthProvider initialAuth={initialAuth}>
              <App>
                <RealtimeProvider>
                  {/* <ContextMenuWrapper>  кастом контекст меню (ПКМ) */}
                    <Layout hasSider style={{ minHeight: "100vh" }}>
                      <Sidebar />
                      <Layout style={{ minWidth: 0 }}>
                        <Content style={{ padding: 0 }}>{children}</Content>
                        <FooterWrapper />
                      </Layout>
                    </Layout>
                  {/* </ContextMenuWrapper> */}
                </RealtimeProvider>
              </App>
            </AuthProvider>
          </Providers>
        </AntdRegistry>
      </body>
    </html>
  );
}