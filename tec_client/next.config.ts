import type { NextConfig } from "next";

const apiUrl = process.env.API_URL;

const nextConfig: NextConfig = {

  async headers() {
    return [
      {
        source: "/:path*",
        headers: [
          { key: "X-Frame-Options", value: "DENY" },
          { key: "X-Content-Type-Options", value: "nosniff" },
          { key: "Referrer-Policy", value: "strict-origin-when-cross-origin" },
          {
            key: "Permissions-Policy",
            value: "camera=(), microphone=(), geolocation=()",
          },
        ],
      },
    ];
  },

  allowedDevOrigins: ["10.0.4.37", "btec.kg", "btec.kg:3000", "localhost:3000"],

  async rewrites() {
    return [
      {
        source: "/api-backend/:path*",
        destination: `${apiUrl}/:path*`,
      },
    ];
  },

  output: 'standalone',
};

export default nextConfig;