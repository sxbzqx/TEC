"use client";

import { useAuth } from "@/hooks/useAuth";
import LandingPage from "@/components/views/LandingPage";
import DashboardPage from "@/components/views/DashboardPage";
import { Spin } from "antd";

export default function MainPage() {
  const { auth, isMounted, isLoading } = useAuth();

  if (!isMounted || isLoading) {
    return (
      <div style={{ display: "flex", justifyContent: "center", alignItems: "center", minHeight: "60vh" }}>
        <Spin size="large" />
      </div>
    );
  }

  return auth.role === "Guest" ? <LandingPage /> : <DashboardPage />;
}